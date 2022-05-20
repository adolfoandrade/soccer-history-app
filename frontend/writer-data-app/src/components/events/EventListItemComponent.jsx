import { Link } from "react-router-dom";

function EventListItemComponent(props) {

    const StyledMatchHeader = {
        color: "#f5f5f5",
        backgroundColor: "#212121",
        padding: "10px",
        fontWeight: "500",
        marginBottom: "20px"
    };

    return (
        <>
            <div style={StyledMatchHeader} key={props.item.match.number}>ROUND {props.item.match.number}</div>
            {props.item.events.map((theEvent) => (
                <>
                    <Link to={`/details/${theEvent.id}`} style={{ textDecoration: 'none' }}>
                        <div style={{
                            borderTopLeftRadius: "12px",
                            borderTopRightRadius: "12px",
                            color: "#212121",
                            display: "flex",
                            justifyContent: "space-between",
                            padding: "10px",
                            borderBotton: "solid 1px #bdbdbd",
                            borderTop: "solid 1px #bdbdbd",
                            borderRight: "solid 1px #bdbdbd",
                            textDecoration: "none",
                            borderLeft: "solid 12px",
                            borderLeftStyle: "solid",
                            borderLeftColor: theEvent.home.colorTheme
                        }}>
                            <div style={{ alignItems: "center", display: "flex" }}>
                                <img style={{ marginRight: "6px" }} alt="" src={`${theEvent.home.image}`} width="32" />{theEvent.home.name}
                            </div>
                            <div>{ theEvent.home.goals } ({ theEvent.home.goalsFirstHalf })</div>
                        </div>
                        <div style={{ 
                            borderBottomLeftRadius: "12px", 
                            borderBottomRightRadius: "12px", 
                            color: "#212121", 
                            display: "flex", 
                            justifyContent: "space-between", 
                            marginBottom: "10px", 
                            padding: "10px", 
                            border: "solid 1px #bdbdbd",
                            textDecoration: "none",
                            borderLeft: "solid 12px",
                            borderLeftStyle: "solid",
                            borderLeftColor: theEvent.out.colorTheme
                        }}>
                            <div style={{ alignItems: "center", display: "flex" }}>
                                <img style={{ marginRight: "6px" }} alt="" src={`${theEvent.out.image}`} width="32" />{theEvent.out.name}
                            </div>
                            <div>{ theEvent.out.goals } ({ theEvent.out.goalsFirstHalf })</div>
                        </div>
                    </Link>
                </>
            ))
            }
        </>
    );
}

export default EventListItemComponent;