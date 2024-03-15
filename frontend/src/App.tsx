import React from 'react';
import './App.css';
import Header from './Header';
import BowlerList from './bowling/BowlerList';

function Welcome() {
  return (
    <>
      <br />
      <h2>This page displays the bowlers for the Marlins and Sharks.</h2>
      <br />
    </>
  );
}

function App() {
  return (
    <div className="App">
      <Header title="Mission 10: Bowling Database" />
      <Welcome />
      <BowlerList />
    </div>
  );
}

export default App;
