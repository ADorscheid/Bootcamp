<template>
  <div>
    <form v-on:submit.prevent="saveRecipe()">
      <div class="RecipeName">
        <label
          for="Recipe Name"
          v-show="!visualParam.name"
          @click="visualParam.name = true"
          >{{ recipe.recipeName }} <span>🖉</span></label
        >
        <input
          v-show="visualParam.name"
          @blur="visualParam.name = false"
          type="text"
          placeholder="Recipe Name"
          v-model="recipe.recipeName"
          name="Recipe Name"
          required="true"
        />
      </div>
      <div class="RecipeType">
        <label
          for="type"
          v-show="!visualParam.type"
          @click="visualParam.type = true"
          >{{ recipe.type }} <span>🖉</span></label
        >
        <select
          v-show="visualParam.type"
          v-model="recipe.type"
          @change="visualParam.type = false"
          @blur="visualParam.type = false"
          name="type"
          required="true"
        >
          <option>Main Dish</option>
          <option>Side Dish</option>
          <option>Beverage</option>
          <option>Dessert</option>
          <option>Appetizer</option>
        </select>
      </div>
      <div class="RecipeServings">
        <label for="numServings">Number of Servings: </label>
        <input
          type="number"
          placeholder="Number of Servings"
          name="numServings"
          v-model="recipe.servings"
          required="true"
          min="1"
        />
      </div>
      <div class="CookTime">
      <label for="cookTime">Cook Time (Minutes):  </label>
      <input
        type="number"
        placeholder="cookTime"
        name="cookTime"
        v-model="recipe.cookTime"
        required="true"
        min="0"
      />
      </div>
      <div>
        <div>Ingredients:</div>
        <div
          v-for="ingredient of recipe.ingredientList"
          v-bind:key="ingredient.ingredientName"
        >
          {{ ingredient.quantity }}
          {{ ingredient.unit }}
          {{ ingredient.ingredientName }}.
          <span
            @click="setupIngredient(recipe.ingredientList.indexOf(ingredient))"
            >🖉</span
          >
          <span
            v-show="visualParam.ingredient"
            @click="deleteIngredient(recipe.ingredientList.indexOf(ingredient))"
            >🗑</span
          >
        </div>
        <label for="Ingredient Quantity">Quantity: </label>
        <input
          type="number"
          name="Ingredient Quantity"
          min="1"
          v-model="ingredient.quantity"
        />
        <label for="Ingredient Unit">Unit: </label>
        <select
          name="Ingredient Unit"
          id="Ingredient_Unit"
          class="unit"
          v-model="ingredient.unit"
        >
          <option value="">no units</option>
          <option value="tsp">teaspoons</option>
          <option value="tbsp">tablespoons</option>
          <option value="cup">cups</option>
          <option value="pint">pints</option>
          <option value="quart">quarts</option>
          <option value="gal">gallons</option>
          <option value="oz">ounces</option>
          <option value="lb">pounds</option>
          <option value="g">grams</option>
          <option value="kg">kilograms</option>
          <option value="ml">milliliters</option>
          <option value="L">liters</option>
          <option value="pinch">pinch</option>
          <option value="dash">dash</option>
        </select>
        <label for="ingredientList">Ingredient: </label>
        <input
          list="ingredients"
          name="ingredientList"
          id="ingredientList"
          v-model="ingredient.ingredientName"
        />
        <button
          type="button"
          @click="addIngredient()"
          v-show="visualParam.ingredient"
        >
          Add Ingredient
        </button>
        <button
          type="button"
          @click="editIngredient()"
          v-show="!visualParam.ingredient"
        >
          Save Edit
        </button>

        <datalist name="ingredients" id="ingredients">
          <option
            v-for="ingredient in allIngredients"
            :key="ingredient.ingredientId"
            :value="ingredient.ingredientName"
          />
        </datalist>
      </div>
      <div class="RecipeInstructions">
        <div>Instructions:</div>
        <div v-for="i of instructionSteps.length" :key="i">
          {{ i }}. {{ instructionSteps[i - 1] }}
          <span @click="editSetup(i - 1)">🖉</span>
          <span @click="deleteStep(i - 1)" v-show="visualParam.addStep">🗑</span>
        </div>
        <input
          type="text"
          name="instructions"
          placeholder="Add Step"
          v-model="recipe.instructions"
        />
        <div>
        <button
          v-show="visualParam.addStep"
          type="button"
          v-on:click.prevent="addStep()"
        >
          Add Instruction Step
        </button>
        </div>
        <button
          v-show="!visualParam.addStep"
          type="button"
          @click.prevent="editStep()"
        >
          Edit Instruction Step
        </button>
      </div>
      <div class="RecipeShare">
        <label for="shared">Set as Public</label>
        <input type="checkbox" v-model="recipe.isShared" name="shared" />
      </div>
      <button type="submit" class="submitBtn">Save Recipe</button>
    </form>
    <!-- eslint-disable -->
    <!-- This disables annoying eslink warning messages in the html       -->
    <!-- This is the dropzone component that will give a place to drop the image to be uploaded -->
    <!-- there are two custom events the component listens for:                                 -->
    <!--       the vdropzone-sending event which is fired when dropzone is sending an image     -->
    <!--       the vdropzone-success event which is fired when dropzone upload is successful    -->
    <vue-dropzone
      id="dropzone"
      class="mt-3"
      v-bind:options="dropzoneOptions"
      v-on:vdropzone-sending="addFormData"
      v-on:vdropzone-success="getSuccess"
      :useCustomDropzoneOptions="true"
    ></vue-dropzone>
  </div>
</template>

<script>
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";
import service from "../services/AuthService.js";
export default {
  name: "upload-photo",
  components: {
    vueDropzone: vue2Dropzone,
  },
  data() {
    return {
      visualParam: {
        name: false,
        type: false,
        addStep: true,
        stepNum: Number,
        ingredient: true,
        ingIndex: Number,
      },
      recipe: {
        recipeName: "Untitled",
        instructions: "",
        type: "Main Dish",
        userId: Number,
        isShared: false,
        servings: 1,
        ingredientList: [],
        newIngredients: [],
        imgUrl: "",
        cookTime: Number
      },
      dropzoneOptions: {
        url: "https://api.cloudinary.com/v1_1/dy5vryv7m/image/upload",
        thumbnailWidth: 250,
        thumbnailHeight: 250,
        maxFilesize: 2.0,
        acceptedFiles: ".jpg, .jpeg, .png, .gif",
        uploadMultiple: false,
        addRemoveLinks: true,
        dictDefaultMessage:
          "Add a photo for your recipe. </br> Drop files here to upload or click to select a file for upload.",
      },
      defaultImages: {
        mainDish: "https://s.clipartkey.com/mpngs/s/145-1459545_dish-hot-dish-black-and-white.png", 
        sideDish: "http://clipart-library.com/img1/1434060.png",
        dessert: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwkpPXe2ARH8rL20z5KrltGNt6nagYNIQpz87cLZ1ntxheJN8&s",
        beverage: "https://s.clipartkey.com/mpngs/s/164-1646965_transparent-noun-clipart-beverages-image-png-black-and.png",
        appetizer: "https://s.clipartkey.com/mpngs/s/268-2686737_appetizer-finger-food-vector-hors-d-oeuvres-clipart.png",
     }, 
     ingredient: {
        quantity: 1,
        unit: "",
        ingredientName: "",
      },
      instructionSteps: [],
      allIngredients: [], // Contains all ingredients currently in db
    };
  },
  methods: {
    /******************************************************************************************
     * The addFormData method is called when vdropzone-sending event is fired
     * it adds additional headers to the request
     ******************************************************************************************/
    addFormData(file, xhr, formData) {
      formData.append("api_key", "654255138794743"); // substitute your api key
      formData.append("upload_preset", "av5w3cm0"); // substitute your upload preset
      formData.append("timestamp", (Date.now() / 1000) | 0);
      formData.append("tags", "vue-app");
    },
    /******************************************************************************************
     * The getSuccess method is called when vdropzone-success event is fired
     ******************************************************************************************/
    getSuccess(file, response) {
      this.recipe.imgUrl = response.secure_url; // store the url for the uploaded image
      this.$emit("image-upload", this.recipe.imgUrl);
    }, // fire custom event with image url in case someone cares
    saveRecipe() {

      if (this.recipe.ingredientList.length === 0 && this.instructionSteps.length === 0)
      {
        alert("Must fill out ingredients and instructions");
      }
      else if (this.recipe.ingredientList.length === 0)
      {
        alert("Must fill out ingredients");
      }
      else if (this.instructionSteps.length === 0)
      {
        alert("Must enter instructions")
      }
      else 
      {

      // this parses numservings into a number
      this.recipe.numServings = parseInt(this.recipe.numServings);
      this.recipe.cookTime = parseInt(this.recipe.cookTime);

      this.checkRecipeForPhoto();
      //this changes recipe type from string into its respective type #

      // this changes recipe type from string into its respective type #
      if (this.recipe.type === "Main Dish") {
        this.recipe.type = 1;
      } else if (this.recipe.type === "Side Dish") {
        this.recipe.type = 2;
      } else if (this.recipe.type === "Beverage") {
        this.recipe.type = 3;
      } else if (this.recipe.type === "Dessert") {
        this.recipe.type = 4;
      } else if (this.recipe.type === "Appetizer") {
        this.recipe.type = 5;
      }

      //this joins all instructions to have all the breaking charater (|||) in the database
      this.recipe.instructions = this.instructionSteps.join("|||");

      service
        .putRecipe(this.recipe)
        .then((response) => {
          if (response.status === 200) {
            this.$store.commit("EDIT_RECIPE", response.data);
            this.$router.push({ name: "profile" });
          }
        })
        .catch((error) => {
          this.errorMsg =
            "was not reponse.status of 200. " + error.response.statusText;
          alert("Error");
        });
      }
    },

    addStep() {
      this.instructionSteps.push(this.recipe.instructions);
      this.recipe.instructions = "";
    },
    editSetup(index) {
      this.recipe.instructions = this.instructionSteps[index];
      this.visualParam.addStep = false;
      this.visualParam.stepNum = index;
    },
    editStep() {
      this.instructionSteps[
        this.visualParam.stepNum
      ] = this.recipe.instructions;
      this.visualParam.addStep = true;
      this.recipe.instructions = "";
    },
      checkRecipeForPhoto(){
      if ( (this.recipe.imgUrl === '') || (this.recipe.imgUrl === this.defaultImages.beverage) || (this.recipe.imgUrl === this.defaultImages.mainDish) || (this.recipe.imgUrl === this.defaultImages.sideDish) || (this.recipe.imgUrl === this.defaultImages.dessert) || (this.recipe.imgUrl === this.defaultImages.appetizer))
      {
        if (this.recipe.type === "Main Dish")
        {
          this.recipe.imgUrl = this.defaultImages.mainDish;
        }
        else if (this.recipe.type === "Side Dish")
        {
          this.recipe.imgUrl = this.defaultImages.sideDish;
        }
        else if (this.recipe.type === "Beverage")
        {
          this.recipe.imgUrl = this.defaultImages.beverage;
        }
        else if (this.recipe.type === "Dessert")
        {
          this.recipe.imgUrl = this.defaultImages.dessert;
        }
        else if (this.recipe.type === "Appetizer")
        {
          this.recipe.imgUrl = this.defaultImages.appetizer;
        }
      }
      },
    deleteStep(index) {
      this.instructionSteps.splice(index, 1);
    },
    deleteIngredient(index) {
      this.recipe.ingredientList.splice(index, 1);
    },
    addIngredient() {
      let chkBool = false;
      this.recipe.ingredientList.forEach((i) => {
        if (i.ingredientName === this.ingredient.ingredientName) {
          chkBool = true;
          alert("Ingredient Already Exists In This Recipe");
        }
      });
      if (!chkBool) {
        //when we click the button add what's in the text fields to ingredient list as an object, if name is not in the options add it to the ingredient array
        this.recipe.ingredientList.push(this.ingredient);
        if (
          !this.allIngredients.find((x) => {
            return x.ingredientName === this.ingredient.ingredientName;
          })
        ) {
          this.recipe.newIngredients.push(this.ingredient.ingredientName);
        }
        this.ingredient = { quantity: 1, unit: "", ingredientName: "" };
      }
    },
    editIngredient() {
      this.recipe.ingredientList[this.visualParam.ingIndex] = this.ingredient;

      //Reset newIngredient list and repopulate with potential new ingredients
      this.recipe.newIngredients = [];
      for (let i of this.recipe.ingredientList) {
        if (
          !this.allIngredients.find((x) => {
            return x.ingredientName === i.ingredientName;
          })
        ) {
          this.recipe.newIngredients.push(i.ingredientName);
        }
      }

      this.ingredient = { quantity: 1, unit: "", ingredientName: "" };
      this.visualParam.ingredient = true;
    },
    setupIngredient(index) {
      this.visualParam.ingIndex = index;
      this.visualParam.ingredient = false;
      this.ingredient = this.recipe.ingredientList[index];
    },
  },
  created() {
    service.getAllIngredients().then((resp) => {
      this.allIngredients = resp.data;
    });
    let tempRecipe = this.$store.state.myRecipes.find((recipe) => {
      return this.$route.params.id == recipe.recipeId;
    });
    this.recipe.recipeId = tempRecipe.recipeId;
    this.instructionSteps = tempRecipe.instructions.split("|||");
    this.recipe.isShared = tempRecipe.isShared;
    this.recipe.recipeName = tempRecipe.recipeName;
    this.recipe.servings = tempRecipe.servings;
    this.recipe.cookTime = tempRecipe.cookTime;
    this.recipe.type =
      tempRecipe.type === 1
        ? "Main Dish"
        : tempRecipe.type === 2
        ? "Side Dish"
        : tempRecipe.type === 3
        ? "Beverage"
        : tempRecipe.type === 4
        ? "Dessert"
        : "Appetizer";
    this.recipe.userId = tempRecipe.userId;
    this.recipe.imgUrl = tempRecipe.imgUrl;

    service.getIngredients(this.recipe).then((resp) => {
      this.recipe.ingredientList = resp.data;
    });
  },
};
</script>

<style scoped>
span:hover {
  color: gray;
  cursor:pointer;
}
form {
  display: flex;
  flex-direction: column;
  align-content: left;
  padding: 100px;
  text-align: left;
}
.RecipeName {
  font-size: 36px;
  font-weight: bold;
  text-align: center;
}
input[type="number"] {
  width: 80px;
}

.RecipeInstructions input[type="text"]{
  width: 80%;
}

button[type="submit"]{
  width: 30%;
  margin-left: auto;
  margin-right: auto;
  height: 7vh;
  font-size: 1.2em;
}

button[type="submit"]:hover{
  cursor: pointer;
}

#dropzone{
    width: 60%;
    margin-left: auto;
    margin-right: auto;
    border-radius: 12px;
}

#dropzone:hover{
    background: rgb(253, 189, 69);
    transition-delay: 0.2s;
    box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24), 0 17px 50px 0 rgba(0,0,0,0.19);
}

form{
  background-color: rgba(255, 255, 255, 0.7);
  -webkit-backdrop-filter: blur(10px);
  backdrop-filter: blur(10px);
  border-radius: 25px;
  margin-bottom: 20px;
}
</style>