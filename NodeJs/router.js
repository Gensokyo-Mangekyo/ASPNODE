import { Router } from "express";
import BuisnessService from "./BuisnessService.js";
const router = new Router()



router.get("/",BuisnessService.Get)

export default router