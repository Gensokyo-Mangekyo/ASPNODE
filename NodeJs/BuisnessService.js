


class BuisnessService {

    async Get(req,resp) {
        resp.send("Hello NodeJs")
    }

   
}

export default new BuisnessService()