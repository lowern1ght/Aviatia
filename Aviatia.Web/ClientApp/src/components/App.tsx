import '../styles/App.css'
import {Card, Layout, Typography} from "antd";
import {Content, Footer, Header} from "antd/es/layout/layout";
import {LoginForm} from "./LoginForm";
import {SiderBar} from "./SiderBar";

function App() {
    return (
        <Layout className="main">
            <SiderBar/>
            <Layout>
                <Header style={{backgroundColor: "white", boxShadow: "inherit", }}>
                    <Typography.Title>
                        Aviatia
                    </Typography.Title>
                </Header>

                <Content style={{margin: "20"}}>
                    <Card style={{display: "flex"}}>
                        <LoginForm/>
                    </Card>
                </Content>

                <Footer style={{textAlign: "center"}}>
                    <Typography.Text
                        type={"secondary"}>
                        @Aviatia by lowern1ght 2023
                    </Typography.Text>
                </Footer>
            </Layout>

        </Layout>
    )
}

export default App