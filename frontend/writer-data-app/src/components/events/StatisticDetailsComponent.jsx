import "./StatisticDetailsComponent.css";

function StatisticDetailsComponent(props) {
    const StyledTimeLineCard = {
        border: "solid 1px #bdbdbd",
        borderRadius: "10px",
        maxWidth: "500px",
        margin: "0 auto 1rem auto",
        justifyContent: "center",
    };
    return (
        <div className="time-line-card" style={StyledTimeLineCard}>
            <table style={{ width: "100%" }}>
                <tr>
                    <th style={{ padding: "10px" }}><img alt="" src={`${props.item?.theEvent?.home?.image}`} width="24" /></th>
                    <th style={{ width: "80%" }}>{props.item?.title}</th>
                    <th style={{ padding: "10px" }}><img alt="" src={`${props.item?.theEvent?.out?.image}`} width="24" /></th>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.ballPossession}%</td>
                    <td className="description-statistic">Ball Possession</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.ballPossession}%</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.goalAttempts}</td>
                    <td className="description-statistic">Goal Attempts</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.goalAttempts}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.shotsOnGoal}</td>
                    <td className="description-statistic">Shots on Goal</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.shotsOnGoal}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.shotsOffGoal}</td>
                    <td className="description-statistic">Shots off Goal</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.shotsOffGoal}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.blockedShots}</td>
                    <td className="description-statistic">Blocked Shots</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.blockedShots}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.freeKicks}</td>
                    <td className="description-statistic">Free Kicks</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.freeKicks}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.cornerKicks}</td>
                    <td className="description-statistic">Corner Kicks</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.cornerKicks}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.offsides}</td>
                    <td className="description-statistic">Offsides</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.offsides}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.throwin}</td>
                    <td className="description-statistic">Throw-in</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.throwin}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.goalkeeperSaves}</td>
                    <td className="description-statistic">Goalkeeper Saves</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.goalkeeperSaves}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.fouls}</td>
                    <td className="description-statistic">Fouls</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.fouls}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.yellowCards}</td>
                    <td className="description-statistic">Yellow Cards</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.yellowCards}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.redCards}</td>
                    <td className="description-statistic">Red Cards</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.redCards}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.totalPasses}</td>
                    <td className="description-statistic">Total Passes</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.totalPasses}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.completedPasses}</td>
                    <td className="description-statistic">Completed Passes</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.completedPasses}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.trackles}</td>
                    <td className="description-statistic">Trackles</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.trackles}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.attacks}</td>
                    <td className="description-statistic">Attacks</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.attacks}</td>
                </tr>
                <tr>
                    <td className="home-statistic">{props.item?.homeFullStatistic?.statistic?.dangerousAttacks}</td>
                    <td className="description-statistic">Dangerous Attacks</td>
                    <td className="out-statistic">{props.item?.awayFullStatistic?.statistic?.dangerousAttacks}</td>
                </tr>
            </table>
        </div>
    );
}

export default StatisticDetailsComponent;