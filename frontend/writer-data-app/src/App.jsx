import { Navigate, Route, Routes } from "react-router-dom";
import "./App.css";
import TeamPage from "./views/Teams/TeamPage/TeamPage";
import EventPage from "./views/Events/EventPage/EventPage";
import TeamForm from "./views/Teams/TeamForm/TeamForm";
import EventForm from "./views/Events/EventForm/EventForm";
import EventDetailsPage from "./views/Events/EventPage/EventDetailsPage";
import AddCommonStatisticComponent from "./views/Events/EventForm/AddCommonStatisticForm";
import TournamentPage from "./views/Tournaments/TournamentPage/TounamentPage";

function App() {
  return (
    <div>
      <Routes>
        <Route path="/" element={<TournamentPage></TournamentPage>}></Route>
        <Route path="/events" element={<EventPage></EventPage>}></Route>
        <Route path="/add" element={<EventForm></EventForm>}></Route>
        <Route path="/details/:id" element={<EventDetailsPage></EventDetailsPage>}></Route>
        <Route path="/statistic/common/add/:id" element={<AddCommonStatisticComponent></AddCommonStatisticComponent>}></Route>
        <Route path="/soccer/team" element={<TeamPage></TeamPage>}></Route>
        <Route path="/soccer/team/form/:id" element={<TeamForm></TeamForm>}></Route>
      </Routes>
    </div>
  );
}

export default App;