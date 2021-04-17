module.exports = function() {
  var faker = require("faker");
  var _ = require("lodash");
  var moment = require("moment");

  function getBackgroundColor(index) {
    let bg = "";
    switch(index) {
      case 1:
        bg = "#1bb698";
        break;
      case 2:
        bg = "#fb826f";
        break;
      case 3:
        bg = "#35284f";
        break;
    }
    return bg;
  }

  var boardIds = [];
  _.times(3, function() {
    return boardIds.push(faker.random.number());
  });
  var cardIds = [];
  _.times(45, function() {
    return cardIds.push(faker.random.number());
  });

  return {
    boards: _.times(3, function(n) {
      return {
        id: boardIds[n],
        title: "My Kanban Board #" + (n+1),
        backgroundColor: getBackgroundColor(n+1)
      };
    }),
    cards: _.times(45, function(x) {
      return  {
        id: cardIds[x],//faker.random.number(),
        boardId: boardIds[Math.floor(x/15)],
        title: faker.random.words(3),
        description: faker.lorem.paragraph(),
        avatar: faker.image.avatar(),
        date: moment(faker.date.recent()).format('MMM Do YYYY'),
        status: _.sample(["Planned", "In Progress", "Completed"]),
        tag: _.sample(["Feature Request", "Design", "Q&A"])
      }
    }),
    comments: _.times(180, function(y) {
      return {
        id: faker.random.number(),
        cardId: cardIds[Math.floor(y/4)],
        author: faker.name.firstName() + ' ' + faker.name.lastName(),
        body: faker.lorem.paragraphs(3),
        postedOn: moment(faker.date.recent()).format('MMMM Do YYYY, h:mm:ss a')
      }
    })
  };

};
