/***************************************************************** */
/***************  Array Functions  ******************************* */
/***************************************************************** */
function arrayFunctions()
{
  // Split a string into an array
    let phrase1 = "When in the course of human events it becomes necessary for one people to dissolve the political bands";
    // split here...

    let words;
    // call printArray here...
    

    // array.slice gets a "sub-array" but does not modify the original
    // array.slice(startElement, nonInclusiveEndElement)
    console.log('*** ***\r\narray.slice gets a "sub-array" but does not modify the original' );
    // slice here...
    let arr;
    printArray(arr);
    printArray(words);
    

    // array.splice gets a "sub-array" and removes those elements.
    // array.splice(start, count, newelements…)
    console.log('*** ***\r\narray.splice gets a "sub-array" and removes those elements.' );
    // splice here...
    printArray(arr);
    printArray(words);


    // array.concat(arr2)
    // array.concat joins two arrays, and does not modify either.
    console.log('*** ***\r\narray.concat joins two arrays, and does not modify either.' );
    // concat here...
    let bigArray;
    printArray(words);
    printArray(arr);
    printArray(bigArray);

}

/**
 * Joins an array of strings together with the - separator and prints to console.
 * @param {string[]} arr The array to be printed
 */
function printArray(arr){
  console.log(arr);
  console.log(arr.join("-"));
}



/***************************************************************** */
/************* Functions and Parameters ************************** */
/***************************************************************** */
/**
 * Write a function called multiplyTogether that multiplies two numbers together. But 
 * what happens if we don't pass a value in? What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */

/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=1] the second parameter to multiply
 */


/**
 * How can I write the multiply function so that it will multiply any number of parameters?
 */


// How can we change this so that it can add up zero to three numbers?

/**
 * 
 * @param {number} num1 A number to add
 * @param {number} num2 A number to add
 * @param {number} num3 A number to add
 * @returns {number} The sum of numbers passed in
 */
function Add(num1, num2, num3) {
  return num1 + num2 + num3;
}


/**
 * How can I write the add function so that it will add any number of parameters?
 */




/***************************************************************** */
/***************** Anonymous Functions  ************************** */
/***************************************************************** */

/*********************************************************
 * Anonymous Functions
 * 
 * Functions are a "first-class object" in JavaScript.  
 * There are numerous ways to define functions.  We have seen just one 
 * way so far... with the "function" keyword similar to how we define a method in C#.
 */
// Anonymous functions
function doubleIt(n){
  return n * 2;
}

/***************************
 * There is actually a "variable" called doubleIt now
 */
// print it...



/************************
 * Now that the function is defined, we can actually "assign" that function to 
 * another variable.
 */


// Call the function doubleIt



// Call the function f



/*****************************
 * Another way to define a function - assign it to a variable directly
 * 
 */



/*******************************
 * And finally, a shortcut for the above using lambda (fat arrow)
 * 
 */


/************************************
 * You may even see a shorter-cut, called an expression-bodied function
 * but I won't use it normally
 */


 
/************************************
 * Now we can write a function, which takes another function as a parameter.
 * The passed-in function can be called (executed / invoked).
 */
function toAllElements(array, functionToApply){

}

/***********************************
 * Define an array of numbers
 */
let myArray = [1,2,3,4,5];

/**********************************
 * Now in the Console window, call toAllElements, passing in myArray, and a function
 * which will perform an operation on every element
 */
//toAllElements(myArray, doubleIt);






/*************************************************************************************
 * Using Anonymous functions
 * ***********************************************************************************
 */

 /**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {}

/***************************************************************** */
/********************* Array Functions  ************************** */
/***************************************************************** */
/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce();
}





let people = [
  { name: "name", age: 21, height: 71 },
];

// List all the people using forEach
function listAllPeople(people) {
}

// Filter people by height or age
function shortPeople(people) {
}

// Map Name to uppercase
function upperName(people) {
}


// Reduce to total height of all people
function totalHeight(people) {
}

// Sort the array

