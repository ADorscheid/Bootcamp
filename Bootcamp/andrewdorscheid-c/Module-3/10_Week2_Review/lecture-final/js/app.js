/**************************************************
 *  Math Practice Notes:

    We need to store this information (variables):
    * Configurable: 
    *       Total Number of questions (10)
    *       Lowest operand value (0)
    *       Highest operand value (9)
    * Game object
    *       Current Question
    *       Number of correct questions
    * Question object
    *       Operand 1 & Operand 2 for current question
    *       An array of possible answers, including the correct one.

    We need to handle these events:
    * User clicks on an answer
    * User clicks on Start Over
    * 
    We need the following functionality:
    * Add event handlers for selecting an answer, and for start over.
    * Start the game (zero score, Reset the current question to 1)
    * Create the next question
    *   Generate two random operands for the next question
    *   Generate four possible answers, shuffled, including the correct answer
    * Display the next question
    *   Take the Js Question object and update screen elements with the questions values
    * Grade the user's answer and increment the score if correct
    *   Go to the next question if there are more,
    *   Or End the game if user has answered all questions
    * End the game
    *   Hide the question and possible answers
*****************************************************/
const NUMBER_OF_QUESTIONS_PER_GAME = 3;
const MIN_OPERAND_VALUE = 0;
const MAX_OPERAND_VALUE = 9;

/*************** Variables to track the game */
let currentQuestion;

let game = {
    currentQuestionNumber: 1,
    numberCorrect: 0,
    startOver: function() {
        this.currentQuestionNumber = 0;
        this.numberCorrect = 0;
        nextQuestion();
    }
};

document.addEventListener('DOMContentLoaded', initialPage);

/**
 * Hook up any event listeners we want to, and start the first game
 */
function initialPage(){
    // Hook up an event listener to the possible answer li's
    let answerLis = document.querySelectorAll('section#answers li');
    answerLis.forEach( (li) =>{
        li.addEventListener('click', userSelectedAnswer);
    });

    // Hook up the event listener for Start Over
    document.getElementById('btnStartOver').addEventListener('click', newGame);
}
function newGame(){
    document.querySelectorAll('.show-hide').forEach( (ele) => {
        ele.classList.remove('hidden');
    });
    game.startOver();
}

function userSelectedAnswer(ev){
    // Grade the answer

    // Get the inner text from the li
    let answerAsString = ev.target.innerText;
    let answer = parseInt(answerAsString);

    gradeAnswer(currentQuestion, answer);

    // Check if we are done, go to endGame if we are, next Question if we are not.
    displayGameStats();

    if (game.currentQuestionNumber === NUMBER_OF_QUESTIONS_PER_GAME){
        endGame();
    }
    else{
        nextQuestion();
    }
}

function endGame(){
    // Hide the stuff we want to hide
    document.querySelectorAll('.show-hide').forEach( (ele) => {
        ele.classList.add('hidden');
    });

}

function nextQuestion(){
    game.currentQuestionNumber++;
    currentQuestion = generateQuestion();
    displayGameStats();
    displayQuestion(currentQuestion);
}

/**
 * Grade the answer and update the game stats
 * @param {Question} question The current question to be graded
 * @param {number} answer The user's answer
 */
function gradeAnswer(question, answer){
    if (question.correctAnswer === answer){
        game.numberCorrect++;
        return true;
    } else {
        return false;
    }

}

// Temporary Code
currentQuestion = generateQuestion();
displayQuestion(currentQuestion);




/**
    * Create the next question
    *   Generate two random operands for the next question
    *   Generate four possible answers, shuffled, including the correct answer
 */
function generateQuestion() {
    let operand1 = getRandomInteger(MIN_OPERAND_VALUE, MAX_OPERAND_VALUE);
    let operand2 = getRandomInteger(MIN_OPERAND_VALUE, MAX_OPERAND_VALUE);

    let possibleAnswers = [];

    // First put the correct answer in the array
    possibleAnswers.push(operand1 * operand2);

    // Then generate three more answers randomly
    for (let i = 1; i <= 3; i++){
        while (possibleAnswers[i] === undefined){
            let randomAnswer = getRandomInteger(MIN_OPERAND_VALUE * MIN_OPERAND_VALUE, MAX_OPERAND_VALUE * MAX_OPERAND_VALUE);
            if ( !possibleAnswers.includes(randomAnswer)){
                possibleAnswers[i] = randomAnswer;
            }
        }
    }

    shuffleArray(possibleAnswers);

    return {
        operand1: operand1,
        operand2: operand2,
        possibleAnswers: possibleAnswers,
        correctAnswer: operand1 * operand2
    }
   
}

function displayQuestion(question){
    let problemDiv = document.querySelector('section#problem > div');
    problemDiv.innerText = `${question.operand1} * ${question.operand2}`;

    let answerLis = document.querySelectorAll('section#answers li');
    for (let i = 0; i < answerLis.length; i++){
        answerLis[i].innerText = question.possibleAnswers[i];
    }
}

function displayGameStats(){
    document.querySelector('span.currentProblem').innerText = game.currentQuestionNumber;
    document.querySelector('span.currentScore').innerText = game.numberCorrect;
    
}




/**
 * Utility function to generate a random number from min to max (inclusive)
 * @param {number} min The lowest integer to return
 * @param {number} max The highest integer to return 
 */
function getRandomInteger(min, max) {
    return min + Math.floor(Math.random() * Math.floor(max - min + 1));
}

/**
 * Utility function to shuffle the items in an array
 * @param {object} arr
 */
 function shuffleArray(arr) {
    return arr.sort(function (a, b) { return Math.random() - 0.5 })
  }