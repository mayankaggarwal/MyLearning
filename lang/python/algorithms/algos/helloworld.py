class helloworld:
    def __init__(self, *args, **kwargs):
        return super().__init__(*args, **kwargs)

    def hello(self,msg):
        print(msg)