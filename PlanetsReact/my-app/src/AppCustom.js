import logo from './colaniops.png';
import saturn from './saturn.png';
import './AppCustom.css';
import React from 'react';

class AppCustom extends React.Component {
  constructor(props){
    super(props)
    this.state = {date: new Date()};
  }

  tick(){
    this.setState({
      date: new Date()
    });
  }

  componentDidMount(){
    this.timerID=setInterval(
      () => this.tick(),
      1000
    );
  }

  render() {
    return (
      <div className="AppCustom">
        <header className="AppCustom-header">
          <img src={logo} className="AppCustom-logo" alt="logo" />



            <div className = "table-container">
                <table className = "table1">
                  <tr className = "table-container-tr">
                    <th>Image</th>
                    <th>Name</th>
                    <th>Type</th>
                  </tr>
                  <td>
                    <img src = {saturn} className = "AppCustom-image"/>
                  </td>
                  <td>Saturn</td>
                  <td>Gas Giant</td>
                </table>
            </div>
          <p>
            Something must go here...
          </p>



          <div className="LoginForm">
              <div className = "LoginTable">
                <form>
                    <label for = "nameInput">Username : </label>
                        <input type = "text" id = "username" name = "usernameInput"></input>
                        <br></br>
                        <label for = "passwordinput">Password : </label>
                        <input type = "text" id = "password" name = "passwordInput"></input>
                </form>
                    
                <div className = "loginButton">
                    <button type = "button">Login</button>
                  </div>
              </div>
          </div>



          <div className = "clock">
                <h3>This is a clock</h3>
                <h2>{this.state.date.toLocaleTimeString()}</h2>
          </div>



        </header>

      </div>

);
  } 
} 
export default AppCustom;