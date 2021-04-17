/*
 * Given 2 strings, return their concatenation, except omit
 * the first char of each. The strings will be at least length 1.
 *   nonStart("Hello", "There") -> "ellohere"
 */
function nonStart(word1, word2) {
  let result = word1.substring(1) + word2.substring(1);
  return result;
  // return ''; //word1.substring(1) + word2.substring(1);
}
