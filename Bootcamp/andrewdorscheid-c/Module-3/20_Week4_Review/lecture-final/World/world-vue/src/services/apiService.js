// This service contains all of the functions which call our API.
import axios from 'axios'

const http = axios.create({
    // Base URL of every endpoint that we will be calling
        baseURL: process.env.VUE_APP_REMOTE_API,
    });

export default {
    getCities(countryCode, district) {
        let url = '/cities';
        if (countryCode){
            url += "?countryCode=" + countryCode;
            
            if (district){
                url += `&district=${district}`;
            }
        }
    
        return http.get(url);
    },

    getCity(id){
        return http.get(`/cities/${id}`);
    },

    addCity(city) {
        return http.post("/cities", city);
    },



}