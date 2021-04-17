// filename: fetchtxt.js

// Hook up the fetch buttons
document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('fetchHotels').addEventListener('click', (e) => {
        startTimer();
        fetchHotelData();
    });
    document.getElementById('fetchReservations').addEventListener('click', (e) => {
        startTimer();
        fetchReservationData();
    });
});

let hotelURL = "https://tehotelreservations.azurewebsites.net/hotels";
let reservationURL = "https://tehotelreservations.azurewebsites.net/reservations";

/*
    Fetch data from a text file and parse the response. (Embedded then's)
*/
let start;

function startTimer(){
    console.clear();
    // clearImages();
    document.getElementById('results').innerHTML = '';
    start = new Date();
}

function logIt(msg){
    console.log((new Date() - start) + "ms: " +  msg);
}

function fetchHotelData() {
    logIt('fetchHotelData 1');
    fetch(hotelURL)             // sends an HTTP request
        .then((response) => {       // get a Response object once this completes
            logIt('fetchHotelData 2');

            // A bad status code (like forbidden) is not an ERR (so will not be caught in catch). We have to check the response code.
            if (response.ok) {
                // 200 status, continue
                response.json()         // Call async function to get the json from the response
                .then((json) => {       // get a string once that completes
                    logIt('fetchHotelData 3');
                    const hoteldata = json;     // The api returns an object with a collection of hotels
                    let table = '<table border="1">' + 
                    '<tr><td>Name</td><td>Star Rating</td><td>Rooms Available</td></tr>'
                    hoteldata.forEach( hotel => {
                        let tr = `<tr><td>${hotel.name}</td><td>${hotel.stars}</td><td>${hotel.roomsAvailable}</td></tr>`
                        table += tr;
                    });
                    table += '</table>';
                    document.getElementById('results').innerHTML = table;
                })
            }
            else
            {
                document.getElementById('results').innerText = `BAD STATUS CODE: ${response.status} ${response.statusText}`;
            }
        }).catch ( (err) => {
            document.getElementById('results').innerText = `There was an ERROR: ${err}`;
        })
        ;
        logIt('fetchHotelData 4');
}

function fetchReservationData() {
    logIt('fetchReservationData 1');
    fetch(reservationURL)             // sends an HTTP request
        .then((response) => {       // get a Response object once this completes
            logIt('fetchReservationData 2');

            // A bad status code (like forbidden) is not an ERR (so will not be caught in catch). We have to check the response code.
            if (response.ok) {
                // 200 status, continue
                response.json()         // Call async function to get the json from the response
                .then((json) => {       // get a string once that completes
                    logIt('fetchReservationData 3');
                    const resdata = json;     // The api returns an object with a collection of hotels
                    let table = '<table border="1">' + 
                    '<tr><td>Id</td><td>Hotel</td><td>Full Name</td><td>Guests</td></tr>'
                    resdata.forEach( res => {
                        let tr = `<tr><td>${res.id}</td><td>${res.hotelId}</td><td>${res.fullName}</td><td>${res.guests}</td></tr>`
                        table += tr;
                    });
                    table += '</table>';
                    document.getElementById('results').innerHTML = table;
                })
            }
            else
            {
                document.getElementById('results').innerText = `BAD STATUS CODE: ${response.status} ${response.statusText}`;
            }
        }).catch ( (err) => {
            document.getElementById('results').innerText = `There was an ERROR: ${err}`;
        })
        ;
        logIt('fetchReservationData 4');
}
