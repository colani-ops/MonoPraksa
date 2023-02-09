
const solarId = "Sol";

let planetArray = []

function Planet(id, name, type, radius, gravity, star){
    this.id = id,
    this.name = name,
    this.type = type,
    this.radius = radius,
    this.gravity = gravity,
    this.star = star
}

const mercury = new Planet(1, "Mercury", "Rocky", 2439.7, 3.7, solarId);

const venus = new Planet(2, "Venus", "Rocky", 6051.8, 8.87, solarId);

const earth = new Planet(3, "Earth", "Rocky", 6371, 9.81, solarId);

const saturn = new Planet(6, "Saturn", "Gas Giant", 58323, 10.44, solarId);

planetArray = [mercury, venus, earth, saturn];

function ListPlanets(){
    
    planetArray = JSON.parse(localStorage.getItem("planetArray")) || [];

    for (i = 0; i < planetArray.length - 1; i++){
        document.getElementById("below").innerHTML += "<div class = 'grid-item'><p>" + JSON.stringify({Id:planetArray[i].id, Name:planetArray[i].name, Type : planetArray[i].type,
        Radius : planetArray[i].radius, Gravity:planetArray[i].gravity, Star:planetArray[i].star}) +"</p></div>";
    }
}

function PostPlanet(){

}

function SearchPlanet(){

}

function DeletePlanet(){

}


