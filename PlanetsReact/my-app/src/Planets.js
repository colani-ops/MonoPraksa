import axios from 'axios';
import React from 'react';
import { Input, FormGroup, Label, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class Planets extends React.Component {

  state = {
    planets: [],

    newPlanetData : {
      name : '',
      type :'',
      radius : 0,
      gravity : 0,
      starSystemID : ''
    },

    editPlanetData : {
      id: '',

      name : '',
      type : '',
      radius : 0,
      gravity : 0,
      starSystemID : '',
    },
    
    newPlanetModal : false,

    editPlanetModal : false,
  }

  componentWillMount(){
    axios.get('https://localhost:44366/api/Planet/get-planet-list/?planetType=&planetName=&planetRadius=&planetGravity=&pageSize=&pageNumber=&orderBy&orderMode').then((response) => {
      this.setState({
        planets: response.data
      })
    })
  }

  toggleNewPlanetModal(){
    //this.state.newPlanetModal = true;
    this.setState({
      newPlanetModal : ! this.state.newPlanetModal
    })
  }

  toggleEditPlanetModal(){
    this.setState({
      editPlanetModal : ! this.state.editPlanetModal
    })
  }



  addPlanet(){
    axios.post('https://localhost:44366/api/Planet/add-planet', this.state.newPlanetData).then((response) => {
      
      let { planets } = this.state;

      planets.push(response.data);

      this.setState(({ planets, newPlanetModal: false, newPlanetData : {
        name : '',
        type :'',
        radius : 0,
        gravity : 0,
        starSystemID : ''
      }}));
    })
  }

  editPlanet(id, name, radius, gravity, starSystemID){
    
    this.setState ({
      editPlanetData: { id, name, radius, gravity, starSystemID },
      editPlanetModal : ! this.state.editPlanetModal
    });
  }

  updatePlanet() {

  }


  


  render() {
    let planets = this.state.planets.map((Planet)=> {
      return (
        <tr>
          <td>{Planet.Name}</td>
          <td>{Planet.Type}</td>
          <td>{Planet.Radius}</td>
          <td>{Planet.Gravity}</td>
          <td>{Planet.StarSystemID}</td>

          <td>
            <button size = "sm" onClick = {this.editPlanet.bind(this, Planet.id, Planet.name, Planet.type,
                                                                Planet.radius, Planet.gravity, Planet.starSystemID )}>
                                                                Edit</button>
            <button size = "sm">Delete</button>
          </td>
                
        </tr>
        )
    });





    return (
      <div className="Planets-app">
        <header className="Planets-app-header">
            <div className = "Planets-app-table-container">
                <h1>Planet Library</h1>
                <table className = "Planets-app-table1">
                  <thead>
                    <tr>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Radius</th>
                        <th>Gravity</th>
                        <th>Star</th>
                        
                        <th>
                          <Modal isOpen = {this.state.newPlanetModal} toggle={this.toggleNewPlanetModal.bind(this)}>
                            <ModalHeader toggle = {this.toggleNewPlanetModal.bind(this)}>Add a new Planet</ModalHeader>
                            <ModalBody>
                              <FormGroup>
                                <Label for = "name">Name : </Label>
                                <Input id = "planetName" placeholder="Planet Name"  value = {this.state.newPlanetData.name} onChange = {(e) => {
                                    
                                    let { newPlanetData } = this.state;
                                    newPlanetData.name = e.target.value;

                                    this.setState({newPlanetData});
                                  }} />
                              </FormGroup>
                              <FormGroup>
                                <Label for = "type">Type : </Label>
                                <Input id = "planetType" placeholder="Planet Type" value = {this.state.newPlanetData.type} onChange = {(e) => {
                                  
                                  let { newPlanetData } = this.state; 
                                  newPlanetData.type = e.target.value;
                                  
                                  this.setState({newPlanetData}); 
                                }}  />
                              </FormGroup>
                              <FormGroup>
                                <Label for = "radius">Radius : </Label>
                                <Input type = "number" id= "planetRadius" placeholder="Planet Radius" value = {this.state.newPlanetData.radius} onChange = {(e) => {
                                  
                                  let {newPlanetData} = this.state;
                                  newPlanetData.radius = e.target.value;
                                  
                                  this.setState({newPlanetData});
                                }}/>
                              </FormGroup>
                              <FormGroup>
                                <Label for = "gravity">Gravity : </Label>
                                <Input type = "number" id= "planetGravity" placeholder="Planet Gravity" value = {this.state.newPlanetData.gravity} onChange = {(e) => {

                                  let {newPlanetData} = this.state;
                                  newPlanetData.gravity = e.target.value;

                                  this.setState({newPlanetData});
                                }} />
                              </FormGroup>
                              <FormGroup>
                                <Label for = "starSystem">Star : </Label>
                                <Input id= "planetStarSystemID" placeholder="StarSystemID" value = {this.state.newPlanetData.starSystemID} onChange = {(e) => {
                                
                                let {newPlanetData} = this.state;
                                newPlanetData.starSystemID = e.target.value;
                                
                                this.setState({newPlanetData});
                                }} />
                              </FormGroup>
                            </ModalBody>
                            
                            <ModalFooter>
                              <button onClick = {this.addPlanet.bind(this)}>Add Planet</button>{' '}
                              <button onClick = {this.toggleNewPlanetModal.bind(this)}>Cancel</button>
                            </ModalFooter>
                          </Modal>



                          <Modal isOpen = {this.state.editPlanetModal} toggle={this.toggleEditPlanetModal.bind(this)}>
                            <ModalHeader toggle = {this.toggleEditPlanetModal.bind(this)}>Edit Selected Planet</ModalHeader>
                            <ModalBody>
                              <FormGroup>
                                <Label for = "name">Name : </Label>
                                <Input id = "planetName" value = {this.state.editPlanetData.name} onChange = {(e) => {
                                    
                                    let { editPlanetData } = this.state;
                                    editPlanetData.name = e.target.value;

                                    this.setState({editPlanetData});
                                  }} />
                              </FormGroup>
                              <FormGroup>
                                <Label for = "type">Type : </Label>
                                <Input id = "planetType" value = {this.state.editPlanetData.type} onChange = {(e) => {
                                  
                                  let { editPlanetData } = this.state; 
                                  editPlanetData.type = e.target.value;
                                  
                                  this.setState({editPlanetData}); 
                                }}  />
                              </FormGroup>
                              <FormGroup>
                                <Label for = "radius">Radius : </Label>
                                <Input type = "number" id= "planetRadius" value = {this.state.editPlanetData.radius} onChange = {(e) => {
                                  
                                  let { editPlanetData } = this.state;
                                  editPlanetData.radius = e.target.value;
                                  
                                  this.setState({editPlanetData});
                                }}/>
                              </FormGroup>
                              <FormGroup>
                                <Label for = "gravity">Gravity : </Label>
                                <Input type = "number" id= "planetGravity" value = {this.state.editPlanetData.gravity} onChange = {(e) => {

                                  let { editPlanetData } = this.state;
                                  editPlanetData.gravity = e.target.value;

                                  this.setState({editPlanetData});
                                }} />
                              </FormGroup>
                              <FormGroup>
                                <Label for = "starSystem">Star : </Label>
                                <Input id= "planetStarSystemID" value = {this.state.editPlanetData.starSystemID} onChange = {(e) => {
                                
                                let { editPlanetData } = this.state;
                                editPlanetData.starSystemID = e.target.value;
                                
                                this.setState({editPlanetData});
                                }} />
                              </FormGroup>
                            </ModalBody>
                            
                            <ModalFooter>
                              <button onClick = {this.updatePlanet.bind(this)}>Apply changes</button>{' '}
                              <button onClick = {this.toggleEditPlanetModal.bind(this)}>Cancel</button>
                            </ModalFooter>
                          </Modal>


                          <button size = "sm">List</button>
                        </th>

                      </tr>
                  </thead>

                  <tbody>
                    {planets}
                  </tbody>
                
                </table>
            
            </div>
          
          <p>
            Something must go here...
            Buttons probably
          </p>
        
        </header>
      
      </div>
    
    );
  } 
} 
export default Planets;