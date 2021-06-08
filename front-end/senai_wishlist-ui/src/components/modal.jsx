import React from 'react';
import ReactDOM from 'react-dom';

const portalRoot = document.getElementById('portal-root');

export default function Modal({ children, isOpen}) {  
  if (!isOpen) {
    return null;
  }

  return ReactDOM.createPortal(
    <div className="modal-overlay">
      <div className="modal">
        <div className="modal-content">
          {children}
        </div>
      </div>
    </div>,
    portalRoot
  );
};