import React, { Component } from "react";
import "./App.css";
import Layout from "../components/Layout/Layout";
import Home from "../components/Home/Home"

import NotFound from "../components/ErrorPages/NotFound/NotFound"
import InternalServer from "../components/ErrorPages/InternalServer/InternalServer"

import asyncComponent from "../hoc/AsyncComponent/AsyncComponent";


import { BrowserRouter, Switch, Route } from "react-router-dom";

const AsyncIssueList = asyncComponent(() => {
  return import("./Issue/IssueList/IssueList");
});

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/issue-list" component={AsyncIssueList} />
            <Route path="/500" component={InternalServer} />
            <Route path="*" component={NotFound} />
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}
export default App;
