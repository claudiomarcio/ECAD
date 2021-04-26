import React, { useState, useEffect } from 'react';
import TelaGestaoMusicas from './Paginas/GestaoMusica';
import * as GestorDeDados from './DataManager';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

  const [data, setData] = useState({ musics: null, genders: null, authors: null });

  const fetchData = async () => {
    const responsemusics = await GestorDeDados.GetMusics(); 
    const responseGenders = await GestorDeDados.GetGender();
    const responseAuthors = await GestorDeDados.GetAuthors();
    setData({ musics: responsemusics, genders: responseGenders, authors: responseAuthors });
  };
 
  useEffect( () => {     
    fetchData() 
  }, [] );

  return (
    <div className="App">
        {data.musics && data.genders && data.authors ? <TelaGestaoMusicas data={data}/> : <div className="musicasnaoencontradas" >Nenhuma musica encontrada.</div> }
    </div>
  );          
}

  // const abrePopupNovaMusica = (_nome, _email, _perfil, _id) => {
  //   setPopupNovoUsuario({ status: true, nome: _nome, email: _email, perfil: _perfil, id: _id });
  // }

export default App;
