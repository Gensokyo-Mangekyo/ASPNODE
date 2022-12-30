import express from 'express'
import cors from 'cors'
import router from './router.js'

const port = 2000 //Порт
const app = express()
app.use(express.json()) 
app.use(cors())

app.use(router)

app.listen(port,() => console.log("server work")) 
