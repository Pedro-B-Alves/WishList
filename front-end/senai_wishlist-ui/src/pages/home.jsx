import { Component } from 'react';
import swal from '@sweetalert/with-react'

import logo from '../img/logo-wishlist.svg';
import search from '../img/search.svg';
import trash from '../img/delete.svg';
import Modal from '../components/modal'

import '../styles/home.css';

export default class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      wishes: [],
      isModalOpen: false,
      email: '',
      pwd: '',
      idUsuario: 0,
      wish: '',
      isLogged: false,
      search: '',
      teste: {},
      hasLoginError: false,
      isAsc: false
    };
  };

  listWishes = () => {
    fetch('http://localhost:5000/api/desejos')
    .then(response => response.json())
    .then(data => this.setState({wishes: data}))
    .catch(error => console.log(error));
  }

  registerWish = async (e) => {
    e.preventDefault();

    await fetch('http://localhost:5000/api/login', {
      method: 'POST',

      body: JSON.stringify({
        email: this.state.email,
        senha: this.state.pwd
      }),

      headers: {
        'Content-Type': 'application/json' 
      }
    })
    .then(response => {
      if (response.status === 200) {
        this.setState({teste: response.json()})
        this.setState({isLogged: true})
      }
    })
    .then(() => this.state.teste.then(data => this.setState({idUsuario: data})))
    .catch(error => {
      console.log(error)
      this.setState({hasLoginError: true})
    })
    .then(() => console.log(this.state.idUsuario))
    .then(() => console.log(this.state.isLogged));

    if (this.state.isLogged) {
      fetch('http://localhost:5000/api/desejos', {
        method: 'POST',
  
        body: JSON.stringify({
          descricao: this.state.wish,
          dataCriacao: new Date().toJSON(),
          idUsuario: this.state.idUsuario
        }),
  
        headers: {
          'Content-Type': 'application/json' 
        }
      })
      .then(response => {
        if (response.status === 201) {
          this.setState({isModalOpen: false});
          this.listWishes();
        }
      })
      .catch(error => console.log(error));
    };
  };

  deleteWish = (idDesejo) => {
    fetch('http://localhost:5000/api/desejos/' + idDesejo, {
      method: 'DELETE'
    })
    .then(response => {
      if (response.status === 204) {
        swal({
          icon: 'success',
          text: 'Desejo deletado com sucesso!',
          button: false,
          timer: 2000
        });
        this.listWishes();
      };
    })
    .catch(error => console.log(error));
  }

  componentDidMount() {
    this.listWishes();
  }

  render() {
    return(
      <>
        <header>
          <img id="logo" src={logo} alt="Logo WishList" />
        </header>

        <main>
          <section id="container">

            <div id="table-top">
              <form id="input-container">
                <label>Buscar desejos</label>
                <div id="input-content">
                  <img src={search} alt="Ícone de busca" />
                  <input 
                    type="text"
                    placeholder="E-mail"
                    value={this.state.search}
                    onChange={e => {this.setState({search: e.target.value}); console.log(this.state.search);}}
                  />
                  {/* <button type="submit"><img src={send} alt="" /></button> */}
                </div>
              </form>

              <div className="flex-end">
                <button className="btn filter" onClick={() => {this.setState({isAsc: !this.state.isAsc}); this.listWishes()}}>Filtrar por data</button>
                <button className="btn" onClick={() => this.setState({isModalOpen: true})}>+ Add desejo</button>
              </div>
            </div>

            <table className="data-table">
              <thead>
                <tr>
                  <th>#</th>
                  <th>Desejo</th>
                  <th>Data</th>
                  <th>Email</th>
                  {/* <th>Ação</th> */}
                </tr>
              </thead>
              <tbody>
                {
                  this.state.isAsc && this.state.wishes.sort((a, b) => new Date(b.dataCriacao) - new Date(a.dataCriacao)),

                  this.state.wishes.filter(w => w.idUsuarioNavigation.email.toLowerCase().includes(this.state.search.toLowerCase())).map(w => {
                    return (
                      <tr key={w.idDesejo}>
                        <td>{w.idDesejo}</td>
                        <td>{w.descricao}</td>
                        <td>{new Date(w.dataCriacao).toLocaleDateString()}</td>
                        <td>{w.idUsuarioNavigation.email}</td>
                        <td><button onClick={() => this.deleteWish(w.idDesejo)}><img src={trash} alt="" /></button></td>
                      </tr>
                    )
                  })
                }
              </tbody>
            </table>

          </section>

          <Modal isOpen={this.state.isModalOpen}>
            <div className="form">
              <h2>Novo desejo</h2>

              <form onSubmit={(e) => this.registerWish(e)}>
                <div className="input-group">
                  <label className="modal-label">E-mail</label>
                  <input 
                    className="modal-input"
                    type="text"
                    value={this.state.email}
                    onChange={e => {this.setState({email: e.target.value})}}
                    required
                  />
                </div>

                <div className="input-group">
                  <label className="modal-label">Senha</label>
                  <input
                    className="modal-input"
                    type="password"
                    value={this.state.pwd}
                    onChange={e => {this.setState({pwd: e.target.value})}}
                    required
                  />
                </div>

                <div className="input-group">
                  <label className="modal-label">Desejo</label>
                  <input
                    className="modal-input"
                    type="text"
                    value={this.state.wish}
                    onChange={e => {this.setState({wish: e.target.value})}}
                    // required
                  />
                </div>

                {
                  this.state.hasLoginError && <span>Falha no login, tente novamente!</span>
                }

                <div className="buttons">
                  <button className="btn cancel" onClick={() => this.setState({isModalOpen: false, hasLoginError: false, email: '', pwd: '', wish: ''})} type="button">Cancelar</button>
                  <button className="btn" type="submit" disabled={this.state.email === '' || this.state.email === '' || this.state.email === '' ? 'none' : ''}>Confirmar</button>
                </div>
              </form>
            </div>
          </Modal>
        </main>
      </>
    );
  };
};
