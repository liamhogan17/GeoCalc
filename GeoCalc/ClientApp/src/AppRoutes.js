import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import ClassList from "./components/ClassList";
import Graphing from "./components/Graphing";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/class-list',
        element: <ClassList />
    },
    {
        path: '/graphing',
        element: <Graphing />
    },
];

export default AppRoutes;
