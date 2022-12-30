import { Router } from "express";
import BuisnessService from "./BuisnessService.js";
const router = new Router()



router.get("/",BuisnessService.Get)
router.post("/character",BuisnessService.Character)

export default router