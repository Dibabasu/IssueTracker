import React from 'react';
import { Container } from 'react-bootstrap';
import Navigation from "../Navigation/Navigation";

const layout = (props) => {
    return (
      <Container>
        <header><Navigation/></header>
        <main>{props.children}</main>
      </Container>
    );
}
export default layout;
