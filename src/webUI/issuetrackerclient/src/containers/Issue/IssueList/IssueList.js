import React, { Component } from "react";
import { Table, Col, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import Aux from "../../../hoc/Auxiliary/Auxiliary";


import { connect } from "react-redux";
import * as repositoryActions from "../../../store/actions/repositoryActions";
import Issue from "../../../components/IssueComponents/Issue/Issue";

class IssueList extends Component {
  componentDidMount = () => {
    let url = "/api/IssueTracker";
    this.props.onGetData(url, { ...this.props });
  };

  render() {
    let owners = [];
    if (this.props.data) {
      owners = this.props.data.items.map((issuedetails) => {
        return (
          <Issue key={issuedetails.id} items={issuedetails} {...this.props} />
        );
      });
    }

    return (
      <Aux>
        <Row>
          <Col mdoffset={10} md={2}>
            <Link to="/createOwner">Create Owner</Link>
          </Col>
        </Row>
        <br />
        <Row>
          <Col md={12}>
            <Table responsive striped>
              <thead>
                <tr>
                  <th>Name</th>
                  <th>Date of birth</th>
                  <th>Address</th>
                  <th>Details</th>
                  <th>Update</th>
                  <th>Delete</th>
                </tr>
              </thead>
              <tbody>{owners}</tbody>
            </Table>
          </Col>
        </Row>
      </Aux>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    data: state.repository.data,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    onGetData: (url, props) => dispatch(repositoryActions.getData(url, props)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(IssueList);
