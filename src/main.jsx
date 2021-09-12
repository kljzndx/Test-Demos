import React from 'react'
import ReactDOM from 'react-dom'

import Test1 from './Test1 - import'
import Test2 from './Test2 - component'

ReactDOM.render(
  <React.StrictMode>
    <Test1 />
  </React.StrictMode>,
  document.getElementById('root')
)
