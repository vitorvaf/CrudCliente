import React, { Component } from "react";
import { Router, Route } from "react-router";
import { Layout } from "./components/Layout/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData/FetchData";
import  FormAdd  from "./components/Form/FormAdd";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>        
          <Route exact path="/" component={FetchData} />
          <Route exact path="/home" component={Home} />
          <Route exact path="/add" component={FormAdd} />        
      </Layout>
    );
  }
}
