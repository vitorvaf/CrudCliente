import React, { Component } from "react";
import { Container, Row, Col, Button } from "reactstrap";

import "./FetchData";
import { Link } from "react-router-dom";

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { clientes: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderTabelaClientes(clientes) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>CPF/CNPJ</th>
            <th>Nome</th>
            <th>Email</th>
            <th>Classificação</th>
            <th>CEP</th>
          </tr>
        </thead>
        <tbody>
          {clientes.map((cliente) => (
            <tr key={cliente.date}>
              <td>{cliente.cpf}</td>
              <td>{cliente.nome}</td>
              <td>{cliente.email}</td>
              <td>{cliente.classificacao}</td>
              <td>{cliente.cep}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Carregando...</em>
      </p>
    ) : (
      FetchData.renderTabelaClientes(this.state.clientes)
    );

    return (
      <Container fluid={true}>
        <Row xs="6">
          <Col xs="10">
            <h1 id="tabelLabel">Clientes</h1>
            <p>Todos os registros na base de dados.</p>
          </Col>
          <Col xs="2">
            {/* <Button variant="primary">Novo</Button> */}
            <Link className="btn btn-secondary" to="/add">Cadastrar</Link>
          </Col>
        </Row>
        <div>{contents}</div>
      </Container>
    );
  }

  async populateWeatherData() {
    const response = await fetch("cliente/listar");
    const data = await response.json();
    this.setState({ clientes: data, loading: false });
  }
}
