


class BuisnessService {

    async Get(req,resp) {
        resp.send("NodeJs")
    }

   
}

export default new BuisnessService()