////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

import React, { Component } from 'react';

/** Базовый (типа абстрактный) компонент */
export class aPage extends Component {
    static displayName = aPage.name;

    constructor(props) {
        super(props);

        /** Создание метода Array.isArray(), если он ещё не реализован в браузере. */
        if (!Array.isArray) {
            Array.isArray = function (arg) {
                return Object.prototype.toString.call(arg) === '[object Array]';
            };
        }

        this.state =
        {
            cardTitle: 'Loading...',
            loading: true
        };
    }

    componentDidMount() {
        this.load();
    }

    render() {
        return (
            <>
                <div className="card">
                    <div className="card-header">
                        <div className="d-flex">
                            <div className="mr-auto p-2">{this.state.cardTitle}</div>
                            <div className="p-2">{this.cardHeaderPanel()}</div>
                        </div>
                    </div>
                    <div className="card-body pb-1">
                        {this.state.loading === true ? <p><em>Загрузка данных...</em></p> : this.cardBody()}
                    </div>
                </div>
            </>
        );
    }
}