
import React, { useState, useEffect, Component } from 'react'
import { Table } from 'react-bootstrap';
import Select from 'react-select'
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';
import * as GestorDeDados from '../DataManager';

const GestaoMusica = (props) => {
    
 const [openPopUp, setOpenPopUp] = useState({ open: false, edit: false, model: null})
 const [codField,setCodField] = useState(0)
 const [nameField,setNameField] = useState('')
 const [genderField,setGenderField] = useState(0)
 const [authorField,setAuthorField] = useState(0)

 // Carrega PopUp para adição ou edição de acordo com a solicitação
  const PopUp = (m, edit) => {       
    setOpenPopUp({ open:true, edit:edit, model:m})  
  }      

  const ClosePopUp = () => {
    setOpenPopUp({ open:false, edit:false})  
  }

  const SaveOrUpdateMusic = async (name, codGender, codAuthor) => {

    if(openPopUp.edit)
      GestorDeDados.EditMusic(codField,nameField,genderField,authorField);
    else
      GestorDeDados.SaveMusic(nameField,genderField,authorField);

     setOpenPopUp({ open:false, edit:false})  
     
  }

  // instancia dropdown de generos
  let optionsGender = props.data.genders ? props.data.genders.map(function (gender) {
    return { value: gender.codGender, label: gender.name };
  }) : []

  // instancia dropdown de autores
  let optionsAuthor = props.data.authors ? props.data.authors.map(function (author) {
    return { value: author.codAuthor, label: author.name };
  }) : []

  // carrega dados da tabela de musica
  let rows =  props.data.musics ? props.data.musics.map((m, index) => {
    return <tr key={index}>
            <td>{m.codMusic}</td>
            <td><input name="name" value={m.name}/></td>            
            <td>
              <Select  
                options={optionsGender} 
                value={optionsGender.filter(function(option) {
                return option.value === m.codGender;
                })}  
              />                                            
            </td>  
            <td>
              <Select  
                options={optionsAuthor} 
                value={optionsAuthor.filter(function(option) {
                return option.value === m.codAuthor;
                })}  
              />                                            
            </td>       
            <td><button onClick={() => {
              PopUp(m, true);
              setCodField(m.codMusic);
              setNameField(m.name);
              setGenderField(m.codGender);
              setAuthorField(m.codAuthor);              
              }}>Edit</button></td>
          </tr>
  }) : []

  // retorna tabela de dados musica
  return (
    <div>
      <h2>Gestão de Musicas</h2>
      <button onClick={() => {PopUp(null,false)}}>Nova Musica</button>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Genero</th>
            <th>Author</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
           {rows}
        </tbody>
      </Table>    
        <Popup 
           open={openPopUp.open}
           closeOnDocumentClick onClose={ClosePopUp}
           position="center" 
           on="click"                     
          >
          <div>
            { openPopUp.edit ?                  
                <div>
                  <h2>Alterar Musica</h2>                    
                  <input name="name" defaultValue={nameField} onChange={(e) => { setNameField(e.target.value)} } />
                  <Select  
                    options={optionsGender}                     
                    value={optionsGender.filter(function(option) {
                    return option.value === genderField;})}
                    onChange={(e) => { setGenderField(e.value)}}  
                  />  
                  <Select  
                    options={optionsAuthor} 
                    value={optionsAuthor.filter(function(option) {
                    return option.value === authorField;})}
                    onChange={(e) => { setAuthorField(e.value)}}    
                  />     
                </div>                  
             :                  
                <div>
                  <h2>Nova Musica</h2>                    
                  <input name="name" onChange={(e) => { setNameField(e.target.value)}} />
                  <Select  
                    name="codGender"
                    options={optionsGender}   
                    onChange={(e) => { setGenderField(e.value)}}                                                 
                  />  
                  <Select  
                    name="codAuthor"
                    options={optionsAuthor}  
                    onChange={(e) => { setAuthorField(e.value)}}                          
                  />     
                </div>                                  
            }
                                                        
            <button
              className="button"
              onClick={(e) => {             
                SaveOrUpdateMusic();
              }}>
              Salvar
          </button>
            <button
              className="button"
              onClick={() => {            
              ClosePopUp();
              }}>
              Fechar
          </button>
        </div>
        </Popup>
       
      
    </div>
    )            
}

export default GestaoMusica