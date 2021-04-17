let name = 'Cigar Parties for Dummies';
let description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
let reviews = [
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
  let container = document.getElementById('reviews');
  container.innerHTML = '';
  reviews.forEach((rev) => {
    // Step 1: Create the element
    let reviewDiv = document.createElement('div');

    // Step 2: Set its properties
    reviewDiv.classList.add('review');
    addReviewer(reviewDiv, rev.reviewer);
    addRating(reviewDiv, rev.rating);
    addTitle(reviewDiv, rev.title);
    addReview(reviewDiv, rev.review);

    // Step 3: Add it to the DOM
    container.insertAdjacentElement('beforeEnd', reviewDiv);
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

  for (let i = 1; i <= numberOfStars; i++) {
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

// LECTURE STARTS HERE ---------------------------------------------------------------

// TODO 01: Add an event listener for DOMContentLoaded and call the methods below only once that event occurs. 
//  We are going to hook up more event handlers, so let's clean it up by creating an initializePage function 
//  to do all our setup stuff.

document.addEventListener('DOMContentLoaded', initializePage);

/**
 * This function is called once the DOM has been loaded, 
 * and it sets up all our event handlers, and display data on
 * the page.
 */
function initializePage() {
  // set the product reviews page title
  setPageTitle();
  // set the product reviews page description
  setPageDescription();
  // display all of the product reviews on our page
  displayReviews();

  // TODO 02: Allow the user to update the Description
  // Get the description "p" element
  let descP = document.querySelector('p.description');
  // TODO 02a: Handle 'click' on the description, and show the edit box, 
  //            while hiding the p with the description in it
  descP.addEventListener('click', (ev) => {
    // Show input, hide p
    enterDescriptionEdit(ev.target)
  });
  // TODO 02b: Handle the keyup event to determine when the user is done editting. If the user pressed Enter, 
  //            save the desc. If they pressed Esc, quit without saving. For all other keys, let the event bubble up.

  document.getElementById('inputDesc').addEventListener('keyup', (ev) => {
    if (ev.key === 'Enter') {
      exitDescriptionEdit(ev.target, true);
    } else if (ev.key === 'Escape') {
      exitDescriptionEdit(ev.target, false);
    }
  });

  // TODO 02c: Also handle the blur event on the textbox, which does the same as 
  //  Esc (quit without saving).
  document.getElementById('inputDesc').addEventListener('blur', (ev) => {
    exitDescriptionEdit(ev.target, false);
  });

  // TODO 03: Allow the user to add a new Review
  // TODO 03a: Handle the click event of the Add Review button. 
  //          Show the form (call showHideForm
  document.getElementById('btnToggleForm').addEventListener('click', showHideForm);

  // TODO 03c: Handle the click event of the Save Review button, and call saveReview().
  document.getElementById('btnSaveReview').addEventListener('click', (ev) => {
    ev.preventDefault();
    saveReview();
  });
}



/**
 * Swap out the description text for a text box to allow the user to edit the description.
 *
 * @param {Event} event the event object
 */
function enterDescriptionEdit(desc) {
  const textBox = desc.nextElementSibling;
  textBox.value = description;
  textBox.classList.remove('d-none');
  desc.classList.add('d-none');
  textBox.focus();
}

/**
 * Swap back from the Textbox to the text element. if "save" is true, change the value of the 
 * data to the contents of the textbox first.
 *
 * @param {Element} Textbox that holds the description
 * @param {Boolean} save should we save the description text
 */
function exitDescriptionEdit(textBox, save) {
  let desc = textBox.previousElementSibling;
  if (save) {
    description = textBox.value;
    setPageDescription();
  }
  textBox.classList.add('d-none');
  desc.classList.remove('d-none');
}

// TODO 03b: Implement Show/Hide form.
/**
 * I will show / hide the add review form.
 */
function showHideForm() {
  /*
    If the form is hidden:
      * Show the form
      * Set the button text to 'Hide Form' or 'Cancel'
      * Set the input focus to the name field
    Else
      * Clear the form (call resetFormValues())
      * Hide the form
      * Set the button text back to 'Add Review'
  */
  let form = document.querySelector('form');
  let addButton = document.getElementById('btnToggleForm');
  if (form.classList.contains('d-none')) {
    form.classList.remove('d-none');
    addButton.innerText = "Hide Form";
    document.getElementById('name').focus();
  } else {
    form.classList.add('d-none');
    addButton.innerText = "Add Review";
    resetFormValues();
  }
}

/**
 * I will reset all of the values in the form.
 */
function resetFormValues() {
  const form = document.querySelector('form');
  const inputs = form.querySelectorAll('input');
  inputs.forEach((input) => {
    input.value = '';
  });
  document.getElementById('rating').value = 1;
  document.getElementById('review').value = '';
}

// TODO 03d: Implement saveReview
// TODO 03e: should the new review show up on the top or bottom of the list?
/**
 * I will save the review that was added using the add review from
 */
function saveReview() {
  /*
  * Get references to all the form controls (name, title, review, rating)
  * Create a new Javascript object for the Review, and set those 4 properties
  * Add the review to the collection of reviews. 
  * Call displayReviews, passing in the new review
  * Hide the form (call showHideForm)
  */
  let nameInput = document.getElementById('name');
  let titleInput = document.getElementById('title');
  let ratingSelect = document.getElementById('rating');
  let reviewTextArea = document.getElementById('review');

  // Create the new review object
  let newReview = {
    reviewer: nameInput.value,
    title: titleInput.value,
    rating: ratingSelect.value,
    review: reviewTextArea.value
  };

  // Add it to the array of reviews
  reviews.unshift(newReview);

  // Now display it in the html
  displayReviews();

  // Hide the form
  showHideForm();

}
