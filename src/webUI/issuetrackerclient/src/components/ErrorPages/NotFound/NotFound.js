import React from "react";
import Alert from "react-bootstrap/Alert"

const notfound = () => {
  return (
    <Alert className="Danger">
      <Alert.Heading>Page Not Found</Alert.Heading>
      <p>404 Page was not found</p>
      <hr />
    </Alert>
  );
};

export default notfound;
