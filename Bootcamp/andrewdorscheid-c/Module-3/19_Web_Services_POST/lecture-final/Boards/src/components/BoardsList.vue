<template>
  <div id="sideNav">
    <h1>My Kanban Boards</h1>
    <div class="boards">
      <div class="status-message error" v-show="errorMsg !== ''">{{errorMsg}}</div>
      <div class="loading" v-if="isLoading">
        <img src="../assets/loading.gif" />
      </div>
      <router-link :to="{ name: 'Board', params: { id: board.id } }"
        class="board"
        v-for="board in this.$store.state.boards"
        v-bind:key="board.id"
        v-bind:style="{ 'background-color': board.backgroundColor }"
        v-else
        tag="div"
      >
        {{ board.title }}
      </router-link>
      <button class="btn addBoard" v-if="!isLoading && !showAddBoard" v-on:click="showAddBoard = !showAddBoard">Add Board</button>
      <form v-if="showAddBoard">
        Board Title:
        <input type="text" class="form-control" v-model="newBoard.title" />
        Background Color:
        <input type="text" class="form-control" v-model="newBoard.backgroundColor" />
        <button type="button" class="btn btn-submit" v-on:click="saveNewBoard">Save</button>
        <button type="button" class="btn btn-cancel" v-on:click.prevent="showAddBoard = !showAddBoard">Cancel</button>
      </form>
    </div>
  </div>
</template>

<script>
import boardsService from '../services/BoardService';

export default {
  data() {
    return {
      isLoading: true,
      showAddBoard: false,
      newBoard: {
        title: '',
        backgroundColor: this.randomBackgroundColor()
      },
      errorMsg: ''
    };
  },
  created() {
    this.retrieveBoards();
  },
  methods: {
    retrieveBoards() {
      boardsService.getBoards().then(response => {
        this.$store.commit("SET_BOARDS", response.data);
        this.isLoading = false;

        if (this.$route.name == "Home" && response.status === 200 && response.data.length > 0) {
          this.$router.push(`/board/${response.data[0].id}`);
        }
      });
    },
    saveNewBoard() {
      // TODO 02: Add the implementation of this function

      // set isLoading to true to inform user.
      this.isLoading = true;

      // Call addBoard on the board service
      boardsService.addBoard(this.newBoard)
        .then( (response) => {
          // When the promise resolves, check for status 201 (created)
          if (response.status === 201) {
              // call retrieveBoards to refresh the page (it will turn off isLoading)
              this.retrieveBoards();
              // hide the form and clear the new board
              this.showAddBoard = false;  
              this.newBoard = {
                title: '',
                backgroundColor: this.randomBackgroundColor()
              };

          }
        }
        ).catch( (err) => {
          if (err.response){
            // Request got to a server, got a response, but the response was non-2xx
            this.errorMsg = `The server returned error ${err.response.status} - ${err.response.statusText}`;
          } else if (err.request) {
            // We created a request, but got NO response
            this.errorMsg = "Error - the server could not be reached.";
          } else {
            // We were not even able to create a request
            this.errorMsg = "Error - unable to create a request.";
          }
        });



      // If there is an error (catch),
          // Test the response and request properties and set the appropriate error message.
          // By setting text to this.errorMsg, the visibility of <div class="status-message error" v-show="errorMsg !== ''">{{errorMsg}}</div> is shown.
          // Set this.isLoading = false to hide animation.

    },
    randomBackgroundColor() {
      return "#" + this.generateHexCode();
    },
    generateHexCode() {
      var bg = Math.floor(Math.random()*16777215).toString(16);
      if (bg.length !== 6) bg = this.generateHexCode();
      return bg;
    }
  }
};
</script>

<style scoped>
div#sideNav {
  height: 100%;
  width: 20%;
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  padding-top: 20px;
  padding-bottom: 20px;
  overflow-x: hidden;
  border-right: solid lightgrey 1px;
}

h1 {
  text-align: center;
}

.boards {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
}
.board {
  color: #f7fafc;
  border-radius: 10px;
  padding: 40px;
  flex: 1;
  margin: 10px;
  text-align: center;
  cursor: pointer;
  width: 60%;
}
.addBoard {
  color: #f7fafc;
  border-radius: 10px;
  background-color: #28a745;
  font-size: 16px;
  width: 60%;
  margin: 10px;
  padding: 20px;
  cursor: pointer;
}
.form-control {
  margin-bottom: 10px;
}
.btn {margin-bottom: 35px;}
.loading {
  flex: 3;
}
.board:hover:not(.router-link-active), .addBoard:hover {
  font-weight: bold;
}
.router-link-active {
  font-weight: bold;
  border: solid blue 5px;
}
</style>
