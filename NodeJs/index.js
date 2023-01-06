import express from 'express'
import cors from 'cors'
import { dirname } from 'path';
import { fileURLToPath } from 'url';
import router from './router.js'
import xml2js from 'xml2js'
import fs from 'fs'
import util from 'util'

const port = 2000 //Порт

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename); 
fs.readFile(__dirname  + "/character.xml",(err,data) => {
    if (err) throw new Error(err)
    const parser =  new  xml2js.Parser()
 parser.parseStringPromise(data).then((res) =>  {
   console.log( util.inspect(res,false,null))
   console.log(res.character.Name[0])
   console.log(res.character.Description[0])
 console.log(res.character.Skills[0].Skill[0].$.Name)
 }
 )
})
const xmlObject = {
   character: {
      Name: {
         _: 'Cirno'
      },
      Description: {
         _: 'Youkai of Darkness'
      },
      Skills: {
         Skill: [
            { '$': { Name: 'Icicle Shoot', Cd: '2' } },     
            { '$': { Name: 'Freeze Touch Me', Cd: '7' } }
          ]
      }
   }
}

const builder = new xml2js.Builder()
const xml = builder.buildObject(xmlObject)
console.log(xml)



const app = express()
app.use(express.json()) 
app.use(cors())

app.use(router)

app.listen(port,() => console.log("server work")) 
