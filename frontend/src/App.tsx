import React, { useEffect,useState } from 'react';
import axios from 'axios'


function App() {

  interface Skill {
    nameSkill: string,
    cd: number
  }
  //ОШИБКА РЕГИСТР первой буквы: Если первая буква c большой задана тогда проосто не найдёт поле Name ~= name
  interface Character {
      name: string,
      surname: string,
      description: string,
      skills: Skill[]
  }  
  

  const [nodejs,setNodeJs] = useState<Character>()
  const [asp,setAsp] = useState<Character>()
  useEffect(() => {
    return () => {
        axios.get<Character>("http://localhost:2000").then((resp) => {
          setNodeJs((resp.data))  
          let character: Character = {
            name: "Marisa" ,
            surname: "Kirisame",
            description: 'She lives in magic forest',
            skills: [ {nameSkill: "Master Spark", cd: 7}, {nameSkill: "Final Spark", cd: 9}]
          }
          axios.post("http://localhost:2000/character",character).then((resp) => console.log(resp.data)).catch(() => console.log("Error"))
        }).catch(() => console.log("Error"))
        axios.get<Character>("https://localhost:7200").then(
          (resp) => {setAsp((resp.data)) 
       }).catch(() => console.log("Error"))
    }
  },[])

  return (
    <div >
    <h1>Answer from Asp.NET</h1>
      <p>Name: {asp?.name}</p>
      <p>Surname: {asp?.surname}</p>
      <p>Description : {asp?.description}</p>
      <h2>Skills</h2>
      {asp?.skills.map((x) => <div >  <p>Name Skill: {x.nameSkill} </p> <p>Cd Skill {x.cd} </p>  </div>)}
      <h1>Answer from NodeJS</h1>
      <p>Name: {nodejs?.name}</p>
      <p>Surname: {nodejs?.surname}</p>
      <p>Description : {nodejs?.description}</p>
      <h2>Skills</h2>
      {nodejs?.skills.map((x) => <div >  <p>Name Skill: {x.nameSkill} </p> <p>Cd Skill {x.cd} </p>  </div>)}
    </div>
  );
}

export default App;
