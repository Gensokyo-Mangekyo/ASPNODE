import React, { useEffect,useState } from 'react';
import axios from 'axios';


function App() {
  const [nodejs,setNodeJs] = useState<string>()
  const [asp,setAsp] = useState<string>()
  useEffect(() => {
    return () => {
        axios.get("http://localhost:2000").then((resp) => {setNodeJs(resp.data) }).catch(() => console.log("Error"))
        axios.get("https://localhost:7200").then((resp) => {setAsp(resp.data) }).catch(() => console.log("Error"))
    }
  },[])

  return (
    <div >
     <p>Hello {nodejs}</p> 
     <p>Hello {asp}</p> 
    </div>
  );
}

export default App;
