import http from ".../http-common";

const getAll = () => {
    return http.get("/Planet");
};

const create = data => {
    return http.post("/Planet", data);
};

const update = (id, data) => {
    return http.put(`/Planet/${targetID}`);
};

const remove = targetID => {
    return http.delete(`/Planet/${taragetID}`);
}

const PlanetService = {
    getAll,
    create,
    update,
    remove
};