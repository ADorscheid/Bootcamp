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
const NUMBER_OF_QUESTIONS_PER_GAME = 10;
const MIN_OPERAND_VALUE = 0;
const MAX_OPERAND_VALUE = 20;

/*************** Variables to track the game */
let game = {
    currentQuestionNumber: 1,
    numberCorrect: 0,
    currentQuestion: null,
    isComplete: false,
    /**
     * Setup a new game
     */
    startGame: function () {
        this.isComplete = false;
        this.currentQuestionNumber = 0;
        this.numberCorrect = 0;
        this.nextQuestion();
    },
    /**
     * Mark the game complete
     */
    endGame: function () {
        this.isComplete = true;
    },
    /**
     * Generate another question
     */
    nextQuestion: function () {
        this.currentQuestionNumber++;
        this.currentQuestion = this.generateQuestion();
    },
    /**
     * Grade the answer and update the game stats
     * @param {number} answer The user's answer
     */
    gradeAnswer: function (answer) {
        if (this.currentQuestion.correctAnswer === answer) {
            this.numberCorrect++;
            return true;
        } else {
            return false;
        }
    },
    /**
    * Create the next question
    *   Generate two random operands for the next question
    *   Generate four possible answers, shuffled, including the correct answer
 */
    generateQuestion: function () {
        let operand1 = getRandomInteger(MIN_OPERAND_VALUE, MAX_OPERAND_VALUE);
        let operand2 = getRandomInteger(MIN_OPERAND_VALUE, MAX_OPERAND_VALUE);

        let possibleAnswers = [];

        // First put the correct answer in the array
        possibleAnswers.push(operand1 * operand2);

        // Then generate three more answers randomly
        for (let i = 1; i <= 3; i++) {
            while (possibleAnswers[i] === undefined) {
                let randomAnswer = getRandomInteger(MIN_OPERAND_VALUE * MIN_OPERAND_VALUE, MAX_OPERAND_VALUE * MAX_OPERAND_VALUE);
                if (!possibleAnswers.includes(randomAnswer)) {
                    possibleAnswers[i] = randomAnswer;
                }
            }
        }

        shuffleArray(possibleAnswers);

        // Create a question object
        return {
            operand1: operand1,
            operand2: operand2,
            possibleAnswers: possibleAnswers,
            correctAnswer: operand1 * operand2
        }
    }
};

document.addEventListener('DOMContentLoaded', initializePage);

/**
 * Hook up any event listeners we want to, and start the first game
 */
function initializePage() {
    // Hook up an event listener to the possible answer li's
    let answerLis = document.querySelectorAll('section#answers li');
    answerLis.forEach((li) => {
        li.addEventListener('click', userSelectedAnswer);
    });

    // Hook up the event listener for Start Over
    document.getElementById('btnStartOver').addEventListener('click', newGame);

    // Start a new game
    newGame();
}

function newGame() {
    game.startGame();
    updateDisplay();
}

function userSelectedAnswer(ev) {
    // Grade the answer
    // Get the inner text from the li
    let answerAsString = ev.target.innerText;
    let answer = parseInt(answerAsString);
    game.gradeAnswer(answer);

    // Check if we are done, go to endGame if we are, next Question if we are not.
    if (game.currentQuestionNumber === NUMBER_OF_QUESTIONS_PER_GAME) {
        game.endGame();
    }
    else {
        game.nextQuestion();
    }
    updateDisplay();
}

function updateDisplay() {
    // Update the problem text
    let question = game.currentQuestion;
    let problemDiv = document.querySelector('section#problem > div');
    problemDiv.innerText = `${question.operand1} * ${question.operand2}`;

    // Update the possible answers
    let answerLis = document.querySelectorAll('section#answers li');
    for (let i = 0; i < answerLis.length; i++) {
        answerLis[i].innerText = question.possibleAnswers[i];
    }

    // Update the game statistics
    document.getElementById('currentProblem').innerText = game.currentQuestionNumber;
    document.getElementById('totalProblems').innerText = NUMBER_OF_QUESTIONS_PER_GAME;
    document.getElementById('currentScore').innerText = game.numberCorrect;

    // Show or hide stuff based on whether the game is inprogress or not.
    if (game.isComplete) {
        // Hide the stuff we want to hide
        document.querySelectorAll('.show-hide').forEach((ele) => {
            ele.classList.add('hidden');
        });
    } else {
        // Hide the stuff we want to hide
        document.querySelectorAll('.show-hide').forEach((ele) => {
            ele.classList.remove('hidden');
        });
    }
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