export async function GetMusics() {

  let caminho = "http://localhost:6001/api/Music/v1/GetMusics"

  return fetch(caminho, {
      method: 'GET',
      headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'         
      }
  })
  .then((res) => {
      return res.json();
  })
  .then((data) => {
      return data;
  })
}

export async function GetGender() {

    let caminho = "http://localhost:6001/api/Music/v1/GetGender"
  
    return fetch(caminho, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'         
        }
    })
    .then((res) => {
        return res.json();
    })
    .then((data) => {
        return data;
    })
  }

  export async function GetAuthors() {

    let caminho = "http://localhost:6001/api/Music/v1/GetAuthors"
  
    return fetch(caminho, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'         
        }
    })
    .then((res) => {
        return res.json();
    })
    .then((data) => {
        return data;
    })
  }

export async function SaveMusic(name, codGender, codAuthor) {
  
  let caminho = "http://localhost:6001/api/Music/v1/SaveMusic";
  
  return fetch(caminho, {
      method: 'POST',
      headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
      },
      body: JSON.stringify({
          name: name,
          codGender: codGender,
          codAuthor: codAuthor
      })
  })
  .then((res) => {
      return res.json();
  })
  .then((data) => {
    
    window.location.reload();
    return data;      
  })
}

export async function EditMusic(codMusic, name, codGender, codAuthor) {
  
  let caminho = "http://localhost:6001/api/Music/v1/EditMusic";
  
  return fetch(caminho, {
      method: 'PUT',
      headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        codMusic:codMusic,
        name: name,
        codGender: codGender,
        codAuthor: codAuthor
    })
  })
  .then((res) => {
      return res.json();
  })
  .then((data) => {
          
    window.location.reload();
    return data;
      
  })
}