/*
    Example of a multi-line comment just like in C#/Java
*/

// Single line comment


/**
 * Functions start with the word function.
 * They don't have a return type and the naming convention is camel-case.
 */
function variables() {
  // Declares a variable where the value cannot be changed
  const daysInWeek = 7;
  printValueAndType("It's daysInWeek", daysInWeek);    // Any comment after a line is ignored

  // Can I change it?
  // daysInWeek = 8; // <== Cannot do this!
  // printValueAndType("daysInWeek", daysInWeek);    // Any comment after a line is ignored


  console.log(`There are ${daysInWeek} days in the week`)

  // Declares a variable those value can be changed
  let n;
  printValueAndType("n", n);
  n = "Tech Elevator";
  printValueAndType("n", n);
  // Can I change it?
  n = 21;
  printValueAndType("n", n);

  // Declare a variable that holds null
  let thing = null;
  printValueAndType("thing", thing);

  // Declare not a number
  let notta = NaN;
  printValueAndType("notta", notta);


  // Declares a variable that will always be an array (prime numbers)
  // const int[] prime = new int[]{1, 3, 5...};
  const prime = [1, 3, 5, 7, 11];
  console.table(prime);

  // Can I change the values in the array?
  prime.push(13);
  console.table(prime);

  // This won't work 
  //prime = [2, 4, 6];

  // Can I re-assign the variable?
  //  prime = "prime numbers";

  // Declare variable obj, but don't define it. Print i=out its value and type

  // Now set it to null, and print out its value and type

  // Return value can be any type.  If there is nothing returned, the value / type is undefined
}

function printValueAndType(name, obj) {
  // Console.WriteLine($"{name}: value is {obj}, type is {typeof (obj)}");
  console.log(`${name}: value is ${obj}, type is ${typeof (obj)}`);
}

/**
 * Functions can also accept parameters.
 * Notice the parameters do not have types.
 * @param {Number} param1 The first number to display
 * @param {Number} param2 The second number to display
 */
function printParameters(param1, param2) {
  console.log(`The value of param1 is ${param1}, and the type is ${typeof (param1)}`);
  console.log(`The value of param2 is ${param2}, and the type is ${typeof (param2)}`);
}

/**
 * Compares two values x and y.
 * == is loose equality
 * === is strict equality
 * @param {Object} x
 * @param {Object} y
 */
function equality(x, y) {
  console.log(`x is ${typeof x}`);
  console.log(`y is ${typeof y}`);

  console.log(`x == y : ${x == y}`); // true
  console.log(`x === y : ${x === y}`); // false
}

/**
 * Each value is inherently truthy or falsy.
 * false, 0, '', null, undefined, and NaN are always falsy
 * everything else is always truthy
 * @param {Object} x The object to check for truthy or falsy,
 */
function falsy(x) {
  if (x) {
    console.log(`${x} is truthy`);
  } else {
    console.log(`${x} is falsy`);
  }
}

/**
 * Arrays can change in size
 * You won't get an Index-out-of-range exception
 * arrays can hold multiple types
 */
function arrays() {
  // Create an empty array
  let junkDrawer = [];  // Empty Array

  // Add some elements by pushing
  junkDrawer.push("Ben");

  // Add some more elements sparsely
  junkDrawer[3] = 99;
  printValueAndType("junkDrawer", junkDrawer);

  // Add a complex type to the array
  let person = {
    name: "Heidi",
    height: 67,
    children: [
      "Rob",
      "Dan"
    ]
  };
  junkDrawer.unshift(person);

  // Remove the last element 
  let lastElement = junkDrawer.pop();
  console.log(lastElement);

  // Use the table command to print the results
  console.table(junkDrawer);
  console.log(`Length of junk drawer is ${junkDrawer.length}`);

  // Loop through the array and print all elements
  // i++ increments by 1
  // i += 1;
  // i = i + 1;
  //
  for (let i = 0; i < junkDrawer.length; i++) {
    printValueAndType(`junkDrawer[${i}]`, junkDrawer[i]);
  }

  return 0;
}

/**
 *  Objects are simple key-value pairs
    - values can be primitive data types
    - values can be arrays
    - or they can be functions
*/
function objects() {
  const person = {
    firstName: "Bill",
    lastName: "Lumbergh",
    age: 42,
    employees: [
      "Peter Gibbons",
      "Milton Waddams",
      "Samir Nagheenanajar",
      "Michael Bolton"
    ],
    introduce: function (pm) {
      let greeting = "Good Morning";
      if (pm) {
        greeting = "Good afternoon";
      }
      return `${greeting}, my name is ${this.firstName} ${this.lastName}. I am (${this.age}) years old.`;
    }
  };

  // Log the object
  console.log(person);
  console.table(person);

  // Log the first and last name
  console.log(`First name is ${person.firstName}`);

  // Change a property
  person.firstName = "Lucky";
  console.log(person);

  // Log each employee
  console.log("Employees:");
  for (emp of person.employees) {
    console.log(`\t${emp}`);
  }

  // Call the object function introduce
  let introduction = person.introduce(true);
  console.log(introduction);
}

/*
########################
Function Overloading
########################

Function Overloading is not available in Javascript. If you declare a
function with the same name, more than one time in a script file, the
earlier ones are overridden and the most recent one will be used.
*/

function Add(num1, num2) {
  console.log("In Add(x,y)");
  return num1 + num2;
}

function Add(num1, num2, num3) {
  console.log("In Add(x,y,z)");
  printValueAndType("num1", num1);
  printValueAndType("num2", num2);
  printValueAndType("num3", num3);
  return num1 + num2 + num3;
}

/*
########################
Math Library
########################

A built-in `Math` object has properties and methods for mathematical constants and functions.
*/

function mathFunctions() {
  console.log("Math.PI : " + Math.PI);
  console.log("Math.LOG10E : " + Math.LOG10E);
  console.log("Math.abs(-10) : " + Math.abs(-10));
  console.log("Math.floor(1.99) : " + Math.floor(1.99));
  console.log("Math.ceil(1.01) : " + Math.ceil(1.01));
  console.log("Math.random() : " + Math.random());
}

/*
########################
String Methods
########################

The string data type has a lot of properties and methods similar to strings in Java/C#
*/

function stringFunctions(value) {


  console.log(`.length -  ${value.length}`);
  console.log(`.endsWith('World') - ${value.endsWith("World")}`);
  console.log(`.startsWith('Hello') - ${value.startsWith("Hello")}`);
  console.log(`.indexOf('Hello') - ${value.indexOf("Hello")}`);

  /*
    Other Methods
        - split(string)
        - substring(number, number)
        - toLowerCase()
        - trim()
        - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    */
  // Split and join
  let s = "    The quick brown fox jumped over the lazy dog.           ";
  s = s.trim();
  console.log(s);
  arr = s.split(" ");
  console.table(arr);
  s = arr.join("...");
  console.log(s);
}

function quirks() {
  // Adding and subtracting strings as numbers
  console.log(`'5' - '2' = ${'5' - '2'}`);
  console.log(`'5' + '2' = ${'5' + '2'}`);

  // Truthiness
  console.log(`0 == false = ${0 == false}`);
  console.log(`1 == true = ${1 == true}`);
  console.log(`2 == true = ${2 == true}`);

  console.log(`2 + true = ${2 + true}`);

  // undefined variables become global. 'use strict' to create an error
  x = 50;

  console.log([2, 11, 21, 1, 4, 32].sort());

  console.log(`Not-a-number is a ${typeof (NaN)}`);
  console.log(`(NaN === NaN) = ${(NaN === NaN)}`);

}
