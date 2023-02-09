import React from 'react';

class LoginForm extends React.Component {
    render(){
        return (
            <div className="LoginForm">
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
        )
    }
}

export default LoginForm;