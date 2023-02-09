import React from 'react';

class Clocky extends React.Component {
    constructor(props){
        super(props)
        this.state = {date: new Date()};
    }
    
    render(){
        return(
            <div className = "clock">
                <h3>This is a clock</h3>
                <h2>{this.state.date.toLocaleTimeString()}</h2>

            </div>
        )
    }
}

export default Clocky;