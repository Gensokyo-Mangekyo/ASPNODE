


class BuisnessService {

    async Get(req,resp) {
        resp.send({"name":"Reimu","Hakurei":"","description":"Shrine Maiden lives in shrine","skills":[{"nameSkill":"Seal Dream","cd":2},{"NameSkill":"Instant Dimension Rift","cd":4}]})
    }

    async Character(req,resp) {
        resp.send("Hello "+ req.body.name)
    }

   
}

export default new BuisnessService()