import React from "react";
import Alert from "react-bootstrap/Alert";

const notfound = () => {
  return (
    <Alert className="Danger">
      <Alert.Heading>Internal Server error</Alert.Heading>
      <p>500 Internal Server error</p>
      <hr />
    </Alert>
  );
};

export default notfound;
