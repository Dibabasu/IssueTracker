import React from "react";
import Aux from "../../../hoc/Auxiliary/Auxiliary";
import { Button } from "react-bootstrap";

const redirectToOwnerDetails = (id, history) => {
  history.push("/issueDetails/" + id);
};

const redirectToUpdateOwner = (id, history) => {
  history.push("/updateIssue/" + id);
};

const rediterctToDeleteOwner = (id, history) => {
  history.push("/deleteIssue/" + id);
};

const issue = (props) => {
  console.log(props);
  return (
    <Aux>
      <tr>
        <td>{props.items.ticketNumber}</td>
        <td>{props.items.created}</td>
        <td>{props.items.catagory}</td>
        <td>
          <Button
            onClick={() =>
              redirectToOwnerDetails(props.items.id, props.history)
            }
          >
            Details
          </Button>
        </td>
        <td>
          <Button
            className="success"
            onClick={() => redirectToUpdateOwner(props.items.id, props.history)}
          >
            Update
          </Button>
        </td>
        <td>
          <Button
            className="danger"
            onClick={() =>
              rediterctToDeleteOwner(props.items.id, props.history)
            }
          >
            Delete
          </Button>
        </td>
      </tr>
    </Aux>
  );
};

export default issue;
