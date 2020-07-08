import React, { Component } from "react";
import { Form, FormGroup, Label, Input } from "reactstrap";
import InputMask from "react-input-mask";

export default class FormAdd extends Component {
  static displayName = Form.name;
  

  constructor(props) {
    super(props);
    this.state = {
      nome: "",
      razaoSocial: "",
      tipoCliente: "",
      cnpj: "",
      cpf: "",
      cep: "",
      email: "",
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange = (event) => {
    const target = event.target.name;
    let value = event.target.value;

    this.setState((state) => {
      switch (target) {
        case "txtNome":
          state.nome = value;
          return { nome: `${state.nome}` };

        case "txtTipoCliente":
          state.tipoCliente = value;
          return { tipoCliente: `${state.tipoCliente}` };

        case "txtRazaoSocial":
          state.razaoSocial = value;
          return { razaoSocial: `${state.razaoSocial}` };

        case "txtCnpj":
          state.cnpj = value;
          return { cnpj: `${state.cnpj}` };

        case "txtCpf":
          state.cpf = value;
          return { cpf: `${state.cpf}` };

        case "txtCep":
          state.cep = value;
          return { cep: `${state.cep}` };

        case "txtEmail":
          state.email = value;
          return { email: `${state.email}` };
      }
    });
  };

  handleSubmit = async (event) => {
    let data = {
      nome: this.state.nome,
      razaoSocial: this.state.razaoSocial,
      cnpj: this.state.cnpj,
      tipoCliente: this.state.tipoCliente === "Juridica" ? 1 : 2,
      cpf: this.state.cpf,
      cep: this.state.cep,
      email: this.state.email,
    };

    var respose = await fetch("cliente", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        console.error(response);
        alert(response.statusText);
        return response;
      })
      .catch((err) => {
        alert(err);
      });
  };
  

  render() {
    
    return (
      <Form>
        <FormGroup>
          <h1>Novo Cliente</h1>
        </FormGroup>
        <FormGroup>
          <Label for="nome">Nome:</Label>
          <Input
            type="text"
            name="txtNome"
            onChange={this.handleChange}
            value={this.state.nome}
            placeholder="informe o nome"
          />
        </FormGroup>
        <FormGroup>
          <Label for="exampleSelect">Tipo de cliente</Label>
          <Input
            type="select"
            name="txtTipoCliente"
            onChange={this.handleChange}
            value={this.state.tipoCliente}
            id="exampleSelect"
          >
            <option>Selecione</option>
            <option>Física</option>
            <option>Jurídica</option>
          </Input>
        </FormGroup>
        <FormGroup>
          <Label for="razao-social">Razão Social:</Label>
          <Input
            type="text"
            name="txtRazaoSocial"
            onChange={this.handleChange}
            value={this.state.razaoSocial}
            placeholder="informe a Razão Social"
          />
        </FormGroup>
        <FormGroup>
          <Label for="cnpj">CNPJ:</Label>
          <InputMask
            className="form-control"
            mask="99.999.999/0001-99"
            type="text"
            name="txtCnpj"
            onChange={this.handleChange}
            value={this.state.cnpj}
            placeholder="informe o CNPJ"
          />
        </FormGroup>
        <FormGroup>
          <Label for="cpf">CPF:</Label>
          <InputMask
            className="form-control"
            mask="999.999.999-99"
            type="cpf"
            name="txtCpf"
            onChange={this.handleChange}
            value={this.state.cpf}
            placeholder="informe o cpf"
          />
        </FormGroup>
        <FormGroup>
          <Label for="nome">CEP</Label>
          <InputMask
            className="form-control"
            mask="99999-999"
            type="cep"
            name="txtCep"
            onChange={this.handleChange}
            placeholder="informe o cep"
            value={this.state.cep}
          />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email:</Label>
          <Input
            name="txtEmail"
            type="email"
            onChange={this.handleChange}
            placeholder="informe o email"
            value={this.state.email}
          />          
        </FormGroup>
        <Input type="button" onClick={this.handleSubmit} value="cadastrar" />
      </Form>
    );
  }
}
