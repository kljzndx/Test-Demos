import React, { Component } from 'react'
import PropTypes from 'prop-types'

function Hello(props) {
  return (
    <div>
      hello {props.name}
    </div>
  )
}

Hello.propTypes = {
  name: PropTypes.string
}

export default class Test2 extends Component {
  render() {
    return (
      <div>
        <Hello name='world'/>

        <div>content</div>
      </div>
    )
  }
}
