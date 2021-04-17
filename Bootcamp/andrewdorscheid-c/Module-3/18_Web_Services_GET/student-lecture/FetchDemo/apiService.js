
const http = axios.create({
});

let apiService = {
  npsURL : 'https://developer.nps.gov/api/v1/parks?parkCode={{park}}&fields=images&api_key=sarrXt7VtO7SLrLPx4h2DzH7uE5ZdtMyFlub7BXY',
  covidURL: "https://api.covid19api.com/summary",
  
  getTextFile() {
    return axios.get('demo.txt');           // send an HTTP request to the relative path 'demo.txt'
  },

  getCovidData() {
    return axios.get(this.covidURL);
  },

  getPark(parkCode) {
    let url = this.npsURL.replace('{{park}}', parkCode);
    return http.get(url);
  }

}
