export default {
    API_URL: "https://tehotelreservations.azurewebsites.net/reviews",
    fetchReviews(store) {
        fetch(this.API_URL)             // sends an HTTP request
            .then((response) => {      // get a Response object once this completes
                // A bad status code (like forbidden) is not an ERR (so will not be caught in catch). We have to check the response code.
                if (response.ok) {
                    // 200 status, continue
                    response.json()         // Call async function to get the json from the response
                        .then((json) => {       // get a string once that completes
                            store.commit('LOAD_REVIEWS', json);
                        })
                }
                else {
                    console.error(`BAD STATUS CODE: ${response.status} ${response.statusText}`);
                }
            }).catch((err) => {
                console.error(`There was an ERROR: ${err}`);
            })
            ;
    },
    postReview(store, review) {
        fetch(this.API_URL, {
            method: "POST",
            body: JSON.stringify(review),
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json"
            }
        })
        .then(() => {
            this.fetchReviews(store);
        });
    }
}