let person = {
    name: "Mike",
    age: 58,
    height: 71,
    address: "Richfield"
};


function displayPerson(){
    console.log(`${person.name}, ${person.address}`)

    for (propName in person){
        console.log(`${propName}: ${person[propName]}`)
    }
}