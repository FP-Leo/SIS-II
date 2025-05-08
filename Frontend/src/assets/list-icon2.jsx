import React from "react";

function ListIcon2() {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 24 24"
    >
      <g fill="#919EAB" fillOpacity="0" stroke="#919EAB" strokeLinecap="round">
        <g strokeDasharray="10" strokeDashoffset="10">
          <circle cx="5" cy="5" r="1.5">
            <animate
              fill="freeze"
              attributeName="stroke-dashoffset"
              dur="0.2s"
              values="10;0"
            ></animate>
            <animate
              fill="freeze"
              attributeName="fill-opacity"
              begin="2.0s"
              dur="0.15s"
              values="0;0.3"
            ></animate>
          </circle>
          <circle cx="5" cy="12" r="1.5">
            <animate
              fill="freeze"
              attributeName="stroke-dashoffset"
              begin="0.7s"
              dur="0.2s"
              values="10;0"
            ></animate>
            <animate
              fill="freeze"
              attributeName="fill-opacity"
              begin="2.2s"
              dur="0.15s"
              values="0;0.3"
            ></animate>
          </circle>
          <circle cx="5" cy="19" r="1.5">
            <animate
              fill="freeze"
              attributeName="stroke-dashoffset"
              begin="1.4s"
              dur="0.2s"
              values="10;0"
            ></animate>
            <animate
              fill="freeze"
              attributeName="fill-opacity"
              begin="2.4s"
              dur="0.15s"
              values="0;0.3"
            ></animate>
          </circle>
        </g>
        <g strokeDasharray="28" strokeDashoffset="28">
          <rect width="11" height="3" x="9.5" y="3.5" rx="1.5">
            <animate
              fill="freeze"
              attributeName="stroke-dashoffset"
              begin="0.1s"
              dur="0.5s"
              values="28;0"
            ></animate>
            <animate
              fill="freeze"
              attributeName="fill-opacity"
              begin="2.0s"
              dur="0.15s"
              values="0;0.3"
            ></animate>
          </rect>
          <rect width="11" height="3" x="9.5" y="10.5" rx="1.5">
            <animate
              fill="freeze"
              attributeName="stroke-dashoffset"
              begin="0.8s"
              dur="0.5s"
              values="28;0"
            ></animate>
            <animate
              fill="freeze"
              attributeName="fill-opacity"
              begin="2.2s"
              dur="0.15s"
              values="0;0.3"
            ></animate>
          </rect>
          <rect width="11" height="3" x="9.5" y="17.5" rx="1.5">
            <animate
              fill="freeze"
              attributeName="stroke-dashoffset"
              begin="1.5s"
              dur="0.5s"
              values="28;0"
            ></animate>
            <animate
              fill="freeze"
              attributeName="fill-opacity"
              begin="2.4s"
              dur="0.15s"
              values="0;0.3"
            ></animate>
          </rect>
        </g>
      </g>
    </svg>
  );
}

export default ListIcon2;
