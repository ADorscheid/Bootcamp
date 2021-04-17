<template>
  <div>
    <h2 @click.prevent="collapse = !collapse">
      <span v-show="!collapse">⮞</span><span v-show="collapse">⮟</span> Grocery
      List
    </h2>
    <section v-show="collapse">
      <label for="mass">Unit of Mass: </label>
      <select name="mass" id="mass" v-model="selectedMass">
        <option v-for="unit of mass" :key="unit" :value="mass.indexOf(unit)">
          {{ unit }}
        </option>
      </select>&nbsp;
      <label for="volume">Unit of Volume: </label>
      <select name="volume" id="volume" v-model="selectedVolume">
        <option
          v-for="unit of volume"
          :key="unit"
          :value="volume.indexOf(unit)"
        >
          {{ unit }}
        </option>
      </select>
      <p @click="toggleChecked($event.currentTarget)" v-for="ingredient in ingredients" :key="ingredient.ingredientName">
        <span v-show="ingredient.mass"
          >{{ ingredient.mass.toFixed(2) }}{{ mass[selectedMass] }}</span
        ><span v-show="ingredient.mass && ingredient.volume">, </span
        ><span v-show="ingredient.mass && ingredient.volume && !ingredient.qty">and</span>
        <span v-show="ingredient.volume"
          > {{ ingredient.volume.toFixed(2) }}{{ volume[selectedVolume] }}</span
        ><span v-show="ingredient.qty && (ingredient.mass || ingredient.volume)"
          >, and</span
        ><span v-show="ingredient.qty"> {{ ingredient.qty }}</span>
        {{ ingredient.name }}
      </p>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      collapse: false,
      mass: ["oz", "lb", "g", "kg"],
      massConversion: [1, 16, 30, 30000],
      volume: [
        "tsp",
        "tbsp",
        "cup",
        "pint",
        "quart",
        "gal",
        "ml",
        "L",
        "pinch",
        "dash",
      ],
      volumeConversion: [1, 3, 48, 96, 192, 768, 5, 5000, 0.0625, 0.125],
      selectedMass: 0,
      selectedVolume: 0,
    };
  },
  props: {
    mealPlan: Object,
  },
  methods: {
    toggleChecked(ingredient){
      ingredient.classList.toggle("checked");
    }
  },
  computed: {
    ingredients() {
      let x = [];
      this.mealPlan.mealList.forEach((meal) => {
        meal.recipes.forEach((recipe) => {
          if (recipe.ingredientList) {
            recipe.ingredientList.forEach((ingredient) => {
              let chkBool = false;
              x.forEach((i) => {
                if (i.name == ingredient.ingredientName) {
                  chkBool = !chkBool;
                }
              });
              if (chkBool) {
                if (this.mass.includes(ingredient.unit)) {
                  x[
                    x.findIndex((j) => {
                      return j.name == ingredient.ingredientName;
                    })
                  ].mass +=
                    ((ingredient.quantity *
                      this.massConversion[this.mass.indexOf(ingredient.unit)]) /
                    this.massConversion[this.selectedMass]);
                } else if (this.volume.includes(ingredient.unit)) {
                  x[
                    x.findIndex((j) => {
                      return j.name == ingredient.ingredientName;
                    })
                  ].volume +=
                    (ingredient.quantity *
                      this.volumeConversion[
                        this.volume.indexOf(ingredient.unit)
                      ]) /
                    this.volumeConversion[this.selectedVolume];
                } else {
                  x[
                    x.findIndex((j) => {
                      return j.name == ingredient.ingredientName;
                    })
                  ].qty += ingredient.quantity;
                }
              } else {
                if (this.mass.includes(ingredient.unit)) {
                  x.push({
                    name: ingredient.ingredientName,
                    qty: 0,
                    mass:
                      (ingredient.quantity *
                        this.massConversion[
                          this.mass.indexOf(ingredient.unit)
                        ]) /
                      this.massConversion[this.selectedMass],
                    volume: 0,
                  });
                } else if (this.volume.includes(ingredient.unit)) {
                  x.push({
                    name: ingredient.ingredientName,
                    qty: 0,
                    mass: 0,
                    volume:
                      (ingredient.quantity *
                        this.volumeConversion[
                          this.volume.indexOf(ingredient.unit)
                        ]) /
                      this.volumeConversion[this.selectedVolume],
                  });
                } else {
                  x.push({
                    name: ingredient.ingredientName,
                    qty: ingredient.quantity,
                    mass: 0,
                    volume: 0,
                  });
                }
              }
            });
          }
        });
      });
      return x;
    },
  },
};
</script>

<style scoped>
.checked{
  text-decoration: line-through;
  color: gray;
}

h2:hover {
  cursor: pointer;
  color: gray;
}

p:hover {
  cursor: pointer;
  color: gray;
}
</style>