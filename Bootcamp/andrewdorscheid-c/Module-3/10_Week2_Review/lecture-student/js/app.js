/**************************************************
 *  Math Practice Notes:

    We need to store this information (variables):
    * Configurable: 
    *       Total Number of questions (10)
    *       Lowest operand value (0)
    *       Highest operand value (9)
    * Current Question
    * Number of correct questions
    * Operand 1 & Operand 2 for current question
    * An array of possible answers, including the correct one.

    We need to handle these events:
    * User clicks on an answer
    * User clicks on Start Over
*****************************************************/






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