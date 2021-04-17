/***************************************************************** */
/***************  Array Functions  ******************************* */
/***************************************************************** */
function arrayFunctions()
{
  // Split a string into an array
    let phrase1 = "When in the course of human events it becomes necessary for one people to dissolve the political bands";
    // split here...
    let words = phrase1.split(" ");
    printArray(words);
    // call printArray here...
    

    // array.slice gets a "sub-array" but does not modify the original
    // array.slice(startElement, nonInclusiveEndElement)
    console.log('*** ***\r\narray.slice gets a "sub-array" but does not modify the original' );
    // slice here...
    let arr = words.slice(3, 7);
    printArray(arr);
    printArray(words);
    

    // array.splice gets a "sub-array" and removes those elements.
    // array.splice(start, count, newelements…)
    console.log('*** ***\r\narray.splice gets a "sub-array" and removes those elements.' );
    // splice here...
    arr = words.splice(3, 4, "middle", "of", "the", "day");
    printArray(arr);
    printArray(words);


    // array.concat(arr2)
    // array.concat joins two arrays, and does not modify either.
    console.log('*** ***\r\narray.concat joins two arrays, and does not modify either.' );
    // concat here...
    let bigArray = words.concat(arr);
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
function multiplyTogether(num1, num2){
  return num1 * num2;
}
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
 function multiplyTogether(num1 = 0, num2 = 1){
  return num1 * num2;
}


/**
 * How can I write the multiply function so that it will multiply any number of parameters?
 */
function multiplyTogether(){
  if (arguments.length === 0)
  {
    return 0;
  }

  let product = 1;
  for (arg of arguments){
    if (typeof(arg) === "number"){
      product *= arg;
    }
  }
  return product;
}


// How can we change this so that it can add up zero to three numbers?

/**
 * This function adds three numbers together
 * 
 * @param {number} num1 A number to add
 * @param {number} num2 A number to add
 * @param {number} [num3 = 0] A number to add
 * @returns {number} The sum of numbers passed in
 */
function Add(num1, num2, num3 = 0) {
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
console.log(`doubleIt is a type ${typeof (doubleIt)}`);


/************************
 * Now that the function is defined, we can actually "assign" that function to 
 * another variable.
 */
let f = doubleIt;
console.log(`f is a type ${typeof (f)}`);

// Call the function doubleIt
let answer = doubleIt(14);
console.log(`The answer is ${answer}`);

// Call the function f
answer = f(100);
console.log(`The answer is ${answer}`);



/*****************************
 * Another way to define a function - assign it to a variable directly
 * 
 */
let tripleIt = function (n) {
  return n*3;
}

answer = tripleIt(333);
console.log(`The answer after calling tripleIt is ${answer}`);



/*******************************
 * And finally, a shortcut for the above using lambda (fat arrow)
 * 
 */
let quadrupleIt = (n) => {
  return n*4;
}

answer = quadrupleIt(400);
console.log(`The answer after calling quadrupleIt is ${answer}`);


/************************************
 * You may even see a shorter-cut, called an expression-bodied function
 * but I won't use it normally
 */
let quintupleIt = (n) => n * 5;

 
/************************************
 * Now we can write a function, which takes another function as a parameter.
 * The passed-in function can be called (executed / invoked).
 * The return value will be a new array with the same number of elements as the original,
 * but each element modified by the functionToApply
 */
function toAllElements(array, functionToApply){
  let resultArray = [];
  for (ele of array){
    resultArray.push( functionToApply(ele)  );
  }
  return resultArray;
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
function allDivisibleByThree(numbersToFilter) {
  // return numbersToFilter.filter(isNumberDivisibleByThree);

  return numbersToFilter.filter( (x) => {
    return x % 3 === 0;
  } );
}

// function isNumberDivisibleByThree(n){
//   return n % 3 === 0;
// }

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
  { name: "Brandon", age: 29, height: 67 },
  { name: "Kameron", age: 20, height: 69 },
  { name: "Robin", age: 29, height: 76 },
  { name: "Jess", age: 23, height: 77 },
  { name: "Paul", age: 25, height: 67 },
];

// List all the people using forEach
function listAllPeople(people) {
  people.forEach( (person) => {
    console.log(person.name);
  });
}

// Filter people by height or age
function shortPeople(people) {
  return people.filter( (p) => {
    return p.height < 72;
  });
}

// Map Name to uppercase
function upperName(people) {
  return people.map( (person) =>{
//    return `${person.name.toUpperCase()} (${person.age})`;
    return { firstName: person.name, birthYear: 2021 - person.age };
  });
}


// Reduce to total height of all people
function totalHeight(people) {
  return people.reduce( (sum, person) => {
    return sum + person.height;
  }, 0 );
}

// Sort the array
/**
 * Function to sort people by age descending
 * @param {array} people The array to sort
 * @returns A sorted array of people
 */
function sortPeople(people){
  return people.sort( (p1, p2) =>{
    // if p1 > p2, return + value
    // if p1 < p2, return - value
    // if ===, return 0
    return p2.age - p1.age;

  });
}

