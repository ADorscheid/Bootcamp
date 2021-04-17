const name = 'Cigar Parties for Dummies';
const description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
const reviews = [
  {
    reviewer: 'Malcolm Gladwell',
    title: 'What a book!',
    review:
      "It certainly is a book. I mean, I can see that. Pages kept together with glue (I hope that's glue) and there's writing on it, in some language.",
    rating: 3
  },
  {
    reviewer: 'Tim Ferriss',
    title: 'Had a cigar party started in less than 4 hours.',
    review:
      "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
    rating: 4
  },
  {
    reviewer: 'Ramit Sethi',
    title: 'What every new entrepreneurs needs. A door stop.',
    review:
      "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
    rating: 1
  },
  {
    reviewer: 'Gary Vaynerchuk',
    title: 'And I thought I could write',
    review:
      "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
    rating: 3
  }
];

/**
 * Add our product name to the page title
 * Get our page page title by the id and the query the .name selector
 * once you have the element you can add the product name to the span.
 */
function setPageTitle() {
  // First, get a reference to the DOM element
  let titleElement = document.querySelector("#page-title > span.name");
  //let titleElement = document.getElementById("page-title").querySelector("span.name");

  // Now set the inner text property so the content changes
  titleElement.innerText = name;
}

/**
 * Add our product description to the page.
 */
function setPageDescription() {
  // 1. Get the element that holds description
  let ele = document.querySelector("#main > p.description");

  // 2. Set its content
  ele.innerText = description;
}

/**
 * I will display all of the reviews on the page.
 * I will loop over the array of reviews and use some helper functions
 * to create the elements needed for our markup and add them to the DOM
 */
function displayReviews() {
  let x = 1;
  reviews.forEach((rev) => {
    // Step 1: Create the element
    let reviewDiv = document.createElement('div');

    // Step 2: Set its properties
    reviewDiv.classList.add('review');
    // reviewDiv.innerText = "Something / anything " + x++;

    addReviewer(reviewDiv, rev.reviewer);
    addRating(reviewDiv, rev.rating);
    addTitle(reviewDiv, rev.title);
    addReview(reviewDiv, rev.review);

    // Step 3: Add it to the DOM
    let main = document.getElementById("main");
    main.insertAdjacentElement('beforeEnd', reviewDiv);
  });
}

/**
 * I will creating a new h4 element with the name of the reviewer and append it to
 * the parent element that is passed to me.
 *
 * @param {HTMLElement} el: The element to append the reviewer to
 * @param {string} name The name of the reviewer
 */
function addReviewer(parent, name) {
  // Create the h4 element
  let h4 = document.createElement('h4');

  // Set the content
  h4.innerText = name;

  // Attach it to the parent
  parent.appendChild(h4);
}

/**
 * I will add the rating div along with a star image for the number of ratings 1-5
 * @param {HTMLElement} parent
 * @param {Number} numberOfStars
 */
function addRating(parent, numberOfStars) {
  // Create the rating container element
  let ratingDiv = document.createElement('div');

  // Set properties
  ratingDiv.classList.add('rating');

  for (let i = 1; i <= numberOfStars; i++){
    // Create an img
    let img = document.createElement('img');
    img.classList.add('ratingStar');
    img.src = "img/star.png";

    // add it to its parent
    ratingDiv.appendChild(img);
  }

  // Add the rating div to the parent
  parent.insertAdjacentElement('beforeEnd', ratingDiv);

}

/**
 * I will add an h3 element along with the review title
 * @param {HTMLElement} parent
 * @param {string} title
 */
function addTitle(parent, title) {
  let titleH3 = document.createElement('h3');
  titleH3.innerText = title;
  parent.appendChild(titleH3);

}

/**
 * I will add the product review
 * @param {HTMLElement} parent
 * @param {string} review
 */
function addReview(parent, review) {
  let p = document.createElement('p');
  p.innerText = review;
  parent.appendChild(p);
}

// set the product reviews page title
setPageTitle();
// set the product reviews page description
setPageDescription();
// display all of the product reviews on our page
displayReviews();
